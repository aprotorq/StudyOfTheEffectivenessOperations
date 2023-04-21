using StudyOfTheEffectivenessOperations.Helpers;
using StudyOfTheEffectivenessOperations.Operation.BidirectionaListOperation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyOfTheEffectivenessOperations.Operation.BinaryTreeOperation
{
    public class BinaryHeapWithMaxOperation
    {
        private int[] heap;
        private int size;

        public BinaryHeapWithMaxOperation()
        {
            heap = new int[VariablesManager.Array.Length];
            size = 0;
            //_array = VariablesManager.Array;
            //heap = new int[_array.Length];
            //size = 0;
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
                    Add(Int32.Parse(Console.ReadLine()));
                    Menu();
                    break;
                //case "3":
                //    Console.Write("Wyszukiwanie liczby w drzewie\r\n");
                //    Search(Int32.Parse(Console.ReadLine()));
                //    break;
                //case "4":
                //    Console.Write("Usuwanie liczby z drzewa\r\n");
                //    Remove(Int32.Parse(Console.ReadLine()));
                //    break;
                case "5":
                    PrintHeap();
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
            Console.WriteLine($"\r\nWpisz 'T' by uruchomić algorytm budowania drzewa na wczytanych {VariablesManager.Array.Length} danych");
            if (Console.ReadKey().Key == ConsoleKey.T)
            {
                Console.WriteLine(Environment.NewLine);
                for (int i = 0; i < VariablesManager.Array.Length - 1; i++)
                {
                    Add(VariablesManager.Array[i]);
                }
                PrintHeap();
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

        private void Swap(int index1, int index2)
        {
            int temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }

        public void Add(int value)
        {
            if (size == heap.Length)
            {
                throw new Exception("kopiec jest pusty");
            }

            heap[size] = value;
            size++;

            int index = size - 1;
            while (index != 0 && heap[index] > heap[Parent(index)])
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        public int Remove()
        {
            if (size == 0)
            {
                throw new Exception("kopiec jest pusty");
            }

            int root = heap[0];
            heap[0] = heap[size - 1];
            size--;

            Heapify(0);

            return root;
        }

        private void Heapify(int index)
        {
            int leftChild = LeftChild(index);
            int rightChild = RightChild(index);
            int largest = index;

            if (leftChild < size && heap[leftChild] > heap[largest])
            {
                largest = leftChild;
            }

            if (rightChild < size && heap[rightChild] > heap[largest])
            {
                largest = rightChild;
            }

            if (largest != index)
            {
                Swap(index, largest);
                Heapify(largest);
            }
        }

        public bool Contains(int value)
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

        public void PrintHeap()
        {
            bool firstTail = true;
            PrintHeap(0, "", true, firstTail);
            Menu();    
        }

        private void PrintHeap(int index, string prefix, bool isTail, bool firsttail)
        {
            Console.WriteLine(prefix + (firsttail? "":(isTail ? "└── " : "├── ")) + heap[index]);

            int leftChild = LeftChild(index);
            int rightChild = RightChild(index);

            if (leftChild < size)
            {
                PrintHeap(leftChild, prefix + (isTail ? "    " : "│   "), rightChild >= size, false);
            }

            if (rightChild < size)
            {
                PrintHeap(rightChild, prefix + (isTail ? "    " : "│   "), true, false);
            }
        }

    }
}
