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
        public Node Root;
        public BinaryTreeOperation()
        {
            _array = FileExt.FileOperation.ArrayNumbers;
            Root = null;
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
                    AddNumberToTree(Int32.Parse(Console.ReadLine()));
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
                    Display();
                    break;
                default:Menu(); 
                    break;
            }
        }
        public void Run()
        {
            Console.WriteLine($"\r\nWpisz 'T' by uruchomić algorytm budowania drzewa na wczytanych {_array.Length} danych");
            if (Console.ReadKey().Key == ConsoleKey.T)
            {

                for (int i = 0; i < _array.Length - 1; i++)
                {
                    AddNumberToTree(_array[i]);
                }
                Display();
            }

        }
        /// <summary>
        /// Metoda dodaje kolejne elementy do kopca binarnego na odpowiednie miejsca w zależności 
        /// czy węzeł/ liść jest większy czy mniejszy od poprzedniego
        /// </summary>
        /// <param name="value"></param>
        public void AddNumberToTree(int value)
        {
            Node newNode = new Node(value);

            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                Node currentNode = Root;

                while (true)
                {
                    if (value < currentNode.Value)
                    {
                        if (currentNode.Left == null)
                        {
                            currentNode.Left = newNode;
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.Left;
                        }
                    }
                    else
                    {
                        if (currentNode.Right == null)
                        {
                            currentNode.Right = newNode;
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.Right;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Metoda, która wyświetla poddrzewa kopca z zależnosciami w formie znaków unicode
        /// </summary>
        /// <param name="node">dany węzeł</param>
        /// <param name="indent">znak z białymi miejscami, który określa miejsce w strukturze</param>
        /// <param name="isLast">tru/false w zależności czy jest to ostatni potomek w węźle czy nie - determinuje sposób wyświetlania </param>
        /// <param name="isRoot">tru/false - jeżli wyśiwetlany jest główny węzeł, nie będzie wyswietlany żaden znak przed nim</param>

        private void DisplaySubtree(Node node, string indent, bool isLast, bool isRoot)
        {
            Console.Write(indent);
            if (isLast)
            {
                Console.Write(isRoot? " " :"└─".PadRight(3));
                indent += "  ";
            }
            else
            {
                Console.Write("├─".PadRight(3));
                indent += "│ ";
            }
            Console.ForegroundColor = isRoot? ConsoleColor.Red: ConsoleColor.Green;
            Console.WriteLine(node.Value.ToString());
            Console.ForegroundColor = ConsoleColor.White;

            if (node.Left != null)
            {
                DisplaySubtree(node.Left, indent, node.Right == null, false);
            }

            if (node.Right != null)
            {
                DisplaySubtree(node.Right, indent, true, false);
            }
        }

        public void Display()
        {
            if (Root == null)
            {
                Console.WriteLine("Brak głównego węzła");
            }
            else
            {
                Console.WriteLine(Environment.NewLine);
                DisplaySubtree(Root, "", true, true);
            }
            Menu();
        }
        public void Remove(int value)
        {
            Root = RemoveNode(Root, value);
            Menu();
        }

        private Node RemoveNode(Node node, int value)
        {
            if (node == null)
            {
                return null;
            }

            if (value < node.Value)
            {
                node.Left = RemoveNode(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = RemoveNode(node.Right, value);
            }
            else
            {
                if (node.Left == null && node.Right == null)
                {
                    node = null;
                }
                else if (node.Left == null)
                {
                    node = node.Right;
                }
                else if (node.Right == null)
                {
                    node = node.Left;
                }
                else
                {
                    Node minNode = FindMinimumInNode(node.Right);
                    node.Value = minNode.Value;
                    node.Right = RemoveNode(node.Right, minNode.Value);
                }
            }

            return node;
        }

        private Node FindMinimumInNode(Node node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }

        public void Search(int value)
        {
            bool result= SearchNode(Root, value);
            string res = result ? "istnieje" : "nie istnieje";
            Console.WriteLine($"Liczba {value} {res} w drzewie");
            Menu();
        }

        private bool SearchNode(Node node, int value)
        {
            if (node == null)
            {
                return false;
            }

            if (value == node.Value)
            {
                return true;
            }
            else if (value < node.Value)
            {
                return SearchNode(node.Left, value);
            }
            else
            {
                return SearchNode(node.Right, value);

            }

        }
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
