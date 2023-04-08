using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace StudyOfTheEffectivenessOperations.Operation.BinaryTreeOperation
{
    public class BinaryTreeOperation
    {
        private int[] _array;
        private int[] heap;
        private int size;

        public BinaryTreeOperation()
        {
            _array = FileExt.FileOperation.ArrayNumbers;
            heap = new int[_array.Length];
            size = 0;
            Menu();
        }
        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Wybierz operację");
            string menu = "[1] Wczytaj dane\r\n";
            menu += "[2] Dodaj liczbę\r\n";
            menu += "[3] Wyszukaj liczbę\r\n";
            menu += "[4] Usuń liczbę jeśli istnieje\r\n";
            menu += "[5] Wyświetl strukturę\r\n";
            menu += "------------------------\r\n";
            menu += "[6] Wyjdź do głównego menu\r\n";
            Console.Write(menu);
            string key = Console.ReadLine();

            switch (key)
            {
                case "1":
                    Console.Write("Tworzenie drzewa binarnego\r\n");
                    Run();
                    break;
                case "2":
                    Console.Write("Podaj liczbę jaką chcesz dodać do węzła\r\n");
                    AddElement(Int32.Parse(Console.ReadLine()));
                    Menu();
                    break;
                case "3":
                    Console.Write("Wyszukiwanie liczby w drzewie\r\n");
                    Search(Int32.Parse(Console.ReadLine()));
                    break;
                case "4":
                    Console.Write("Usuwanie liczby z drzewa\r\n");
                    Remove(Int32.Parse(Console.ReadLine()));
                    break;
                case "5":
                    Print();
                    break;
                case "6":
                    MainMenu.ShowMenu();
                    break;
                default:
                    Menu();
                    break;
            }
        }
        public void Run()
        {
            Console.WriteLine($"\r\nWpisz 'T' by uruchomić algorytm budowania drzewa na wczytanych {_array.Length} danych");
            if (Console.ReadKey().Key == ConsoleKey.T)
            {
                Console.WriteLine(Environment.NewLine );
                for (int i = 0; i < _array.Length - 1; i++)
                {
                    AddElement(_array[i]);
                }
                Print();
            }
        }

        private int Parent(int index)
        {
            return (index - 1) / 2;
        }

        private int LeftChild(int index)
        {
            return 2 * index + 1;
        }

        private int RightChild(int index)
        {
            return 2 * index + 2;
        }

        private void Change(int index1, int index2)
        {
            int temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }

        private void StertaUp(int index)
        {
            while (index > 0 && heap[index] > heap[Parent(index)])
            {
                Change(index, Parent(index));
                index = Parent(index);
            }
        }

        private void StertaDown(int index)
        {
            int maxIndex = index;
            int leftChildIndex = LeftChild(index);
            int rightChildIndex = RightChild(index);

            if (leftChildIndex < size && heap[leftChildIndex] > heap[maxIndex])
            {
                maxIndex = leftChildIndex;
            }

            if (rightChildIndex < size && heap[rightChildIndex] > heap[maxIndex])
            {
                maxIndex = rightChildIndex;
            }

            if (index != maxIndex)
            {
                Change(index, maxIndex);
                StertaDown(maxIndex);
            }
        }

        public void AddElement(int value)
        {
            if (size == heap.Length)
            {
                throw new InvalidOperationException("Heap is full");
            }

            heap[size] = value;
            size++;
            StertaUp(size - 1);
        }

        public int ExtractMax()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            int result = heap[0];
            heap[0] = heap[size - 1];
            size--;
            StertaDown(0);
            return result;
        }

        public bool Search(int value)
        {
            for (int i = 0; i < size; i++)
            {
                if (heap[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        public void Remove(int value)
        {
            int index = -1;
            for (int i = 0; i < size; i++)
            {
                if (heap[i] == value)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                throw new InvalidOperationException("Value not found in heap");
            }

            heap[index] = heap[size - 1];
            size--;
            StertaDown(index);
            StertaUp(index);
        }

        public void Print()
        {
            for (int i = 0; i < size; i++)
            {
                int height = (int)Math.Floor(Math.Log(i + 1, 2));
                int spaceCount = (1 << (height + 1)) - 2;

                // print spaces before current node
                Console.Write(new string(' ', spaceCount));

                // print current node
                Console.Write(heap[i]);

                // print spaces after current node
                Console.Write(new string(' ', spaceCount));

                // if current node is not root
                if (i > 0)
                {
                    // determine if current node is left or right child of parent
                    bool isLeftChild = (i - 1) % 2 == 0;
                    int parentIndex = (i - 1) / 2;

                    // print arrows to parent
                    if (isLeftChild)
                    {
                        Console.Write(" /");
                        Console.Write(new string(' ', spaceCount - 1));
                    }
                    else
                    {
                        Console.Write(new string(' ', spaceCount));
                        Console.Write("\\");
                    }

                    // print spaces between parent and current node's sibling
                    int siblingIndex = isLeftChild ? i : i - 2;
                    int siblingHeight = (int)Math.Floor(Math.Log(siblingIndex + 1, 2));
                    int siblingSpaceCount = (1 << (siblingHeight + 1)) - 2;
                    Console.Write(new string(' ', siblingSpaceCount));

                    // if current node is right child and its sibling is last node in current level, move to next line
                    if (!isLeftChild && siblingIndex == (1 << (siblingHeight + 1)) - 2)
                    {
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            //for (int i = 0; i < size; i++)
            //{
            //    int height = (int)Math.Floor(Math.Log(i + 1, 2));
            //    Console.Write(new string(' ', (1 << (height + 1)) - 2));
            //    Console.Write(heap[i]);
            //    Console.Write(new string(' ', (1 << (height + 1)) - 2));
            //    if ((1 << (height + 1)) - 1 == i + 1)
            //    {
            //        Console.WriteLine();
            //    }
            //}
            //Console.WriteLine();
            Menu();
        }
        //public void Run()
        //{
        //    Console.WriteLine($"\r\nWpisz 'T' by uruchomić algorytm budowania drzewa na wczytanych {_array.Length} danych");
        //    if (Console.ReadKey().Key == ConsoleKey.T)
        //    {

        //        for (int i = 0; i < _array.Length - 1; i++)
        //        {
        //            AddNumberToTree(_array[i]);
        //        }
        //        Display();
        //    }

        //}
        /// <summary>
        /// Metoda dodaje kolejne elementy do kopca binarnego na odpowiednie miejsca w zależności 
        /// czy węzeł/ liść jest większy czy mniejszy od poprzedniego
        /// </summary>
        /// <param name="value"></param>
        //public void AddNumberToTree(int value)
        //{
        //    Node newNode = new Node(value);

        //    if (Root == null)
        //    {
        //        Root = newNode;
        //    }
        //    else
        //    {
        //        Node currentNode = Root;

        //        while (true)
        //        {
        //            if (value < currentNode.Value)
        //            {
        //                if (currentNode.Left == null)
        //                {
        //                    currentNode.Left = newNode;
        //                    break;
        //                }
        //                else
        //                {
        //                    currentNode = currentNode.Left;
        //                }
        //            }
        //            else
        //            {
        //                if (currentNode.Right == null)
        //                {
        //                    currentNode.Right = newNode;
        //                    break;
        //                }
        //                else
        //                {
        //                    currentNode = currentNode.Right;
        //                }
        //            }
        //        }
        //    }
        //}
        /// <summary>
        /// Metoda, która wyświetla poddrzewa kopca z zależnosciami w formie znaków unicode
        /// </summary>
        /// <param name="node">dany węzeł</param>
        /// <param name="indent">znak z białymi miejscami, który określa miejsce w strukturze</param>
        /// <param name="isLast">tru/false w zależności czy jest to ostatni potomek w węźle czy nie - determinuje sposób wyświetlania </param>
        /// <param name="isRoot">tru/false - jeżli wyśiwetlany jest główny węzeł, nie będzie wyswietlany żaden znak przed nim</param>

        //private void DisplaySubtree(Node node, string indent, bool isLast, bool isRoot)
        //{
        //    Console.Write(indent);
        //    if (isLast)
        //    {
        //        Console.Write(isRoot? " " :"└─".PadRight(3));
        //        indent += "  ";
        //    }
        //    else
        //    {
        //        Console.Write("├─".PadRight(3));
        //        indent += "│ ";
        //    }
        //    Console.ForegroundColor = isRoot? ConsoleColor.Red: ConsoleColor.Green;
        //    Console.WriteLine(node.Value.ToString());
        //    Console.ForegroundColor = ConsoleColor.White;

        //    if (node.Left != null)
        //    {
        //        DisplaySubtree(node.Left, indent, node.Right == null, false);
        //    }

        //    if (node.Right != null)
        //    {
        //        DisplaySubtree(node.Right, indent, true, false);
        //    }
        //}

        //public void Display()
        //{
        //    if (Root == null)
        //    {
        //        Console.WriteLine("Brak głównego węzła");
        //    }
        //    else
        //    {
        //        Console.WriteLine(Environment.NewLine);
        //        DisplaySubtree(Root, "", true, true);
        //    }
        //    Menu();
        //}
        //public void Remove(int value)
        //{
        //    Root = RemoveNode(Root, value);
        //    Menu();
        //}

        //private Node RemoveNode(Node node, int value)
        //{
        //    if (node == null)
        //    {
        //        return null;
        //    }

        //    if (value < node.Value)
        //    {
        //        node.Left = RemoveNode(node.Left, value);
        //    }
        //    else if (value > node.Value)
        //    {
        //        node.Right = RemoveNode(node.Right, value);
        //    }
        //    else
        //    {
        //        if (node.Left == null && node.Right == null)
        //        {
        //            node = null;
        //        }
        //        else if (node.Left == null)
        //        {
        //            node = node.Right;
        //        }
        //        else if (node.Right == null)
        //        {
        //            node = node.Left;
        //        }
        //        else
        //        {
        //            Node minNode = FindMinimumInNode(node.Right);
        //            node.Value = minNode.Value;
        //            node.Right = RemoveNode(node.Right, minNode.Value);
        //        }
        //    }

        //    return node;
        //}

        //private Node FindMinimumInNode(Node node)
        //{
        //    while (node.Left != null)
        //    {
        //        node = node.Left;
        //    }

        //    return node;
        //}

        //public void Search(int value)
        //{
        //    bool result= SearchNode(Root, value);
        //    string res = result ? "istnieje" : "nie istnieje";
        //    Console.WriteLine($"Liczba {value} {res} w drzewie");
        //    Menu();
        //}

        //private bool SearchNode(Node node, int value)
        //{
        //    if (node == null)
        //    {
        //        return false;
        //    }

        //    if (value == node.Value)
        //    {
        //        return true;
        //    }
        //    else if (value < node.Value)
        //    {
        //        return SearchNode(node.Left, value);
        //    }
        //    else
        //    {
        //        return SearchNode(node.Right, value);

        //    }

        //}
    }
    /// <summary>
    /// Klasa okresląjąca model kopca
    /// </summary>
    public class Node
    {
        public int Value;
        public Node Left;
        public Node Right;

        public Node(int value)
        {
            Value = value;
        }
    }
}
