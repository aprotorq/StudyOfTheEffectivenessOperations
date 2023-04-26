using StudyOfTheEffectivenessOperations.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace StudyOfTheEffectivenessOperations.Operation.BinaryTreeOperation
{
    public class BinaryHeapWithMaxOperation
    {
        private int[] sterta;
        private int size;
        public Random rnd = new Random();
        private Stopwatch sw = Stopwatch.StartNew();
        private double[] times = new double[100];
        public int count;
        const int maxValue = 100000;
        public BinaryHeapWithMaxOperation()
        {
            
            count = VariablesManager.IsManual == true ? VariablesManager.Array.Length : VariablesManager.QuantityToAutoFill;
            sterta = new int[count];
            size = 0;
            Menu();
        }
        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Wybierz operację");
            string menu = "[1] Dodaj liczbę\r\n";
            menu += "[2] Wyszukaj liczbę\r\n";
            menu += "[3] Usuń liczbę z danego indeksu\r\n";
            menu += "[4] Wyświetl strukturę\r\n";
            menu += "------------------------\r\n";
            menu += "[5] Wyjdź do głównego menu\r\n";
            Console.Write(menu);
            string key = Console.ReadLine();

            switch (key)
            {
               
                case "1":
                    AddItemToTree();
                    break;
                case "2":
                    Console.Write("Wyszukiwanie liczby w drzewie\r\n");
                    Find();
                    break;
                case "3":
                    Console.Write("Usuwanie liczby na danym indexie z drzewa\r\n");
                    RemoveElement();
                    break;
                case "4":
                    Display();
                    break;
                case "5":
                    MainMenu.ShowMenu();
                    break;
                default:
                    Menu();
                    break;
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

        private void ChangePlace(int index1, int index2)
        {
            int temp = sterta[index1];
            sterta[index1] = sterta[index2];
            sterta[index2] = temp;
        }

        public void AddItemToTree()
        {
            int iterations = 100;
            for (int i = 0; i < iterations; i++)
            {
                sterta = new int[count];
                size = 0;
                if (VariablesManager.IsManual)
                {

                    for (int j = 0; j < count -1; j++)
                    {   
                        sw.Restart();
                        sterta[size] = VariablesManager.Array[j];
                        size++;
                       
                        int index = size - 1;
                        while (index != 0 && sterta[index] > sterta[Parent(index)])
                        {
                            ChangePlace(index, Parent(index));
                            index = Parent(index);
                        }
                        sw.Stop();
                    }
                    if (size == sterta.Length)
                    {
                        MainMenu.ColorizeString("kopiec jest pusty",ConsoleColor.Red);
                    }
                }
                else
                {
                    for (int j = 0; j < count -1; j++)
                    {
                        sw.Restart();
                        sterta[size] = rnd.Next(maxValue);
                        size++;

                        int index = size - 1;
                        while (index != 0 && sterta[index] > sterta[Parent(index)])
                        {
                            ChangePlace(index, Parent(index));
                            index = Parent(index);
                        }
                        sw.Stop();
                    }
                    if (size == sterta.Length)
                    {
                        MainMenu.ColorizeString("kopiec jest pusty", ConsoleColor.Red);
                    }
                }
                
                times[i] = sw.Elapsed.TotalMilliseconds * 1000000;
            }
            Console.WriteLine($"Czas najmniejszy: {times.Min()} ms, czas najwiekszy: {times.Max()} ms, czas średni: {times.Average()} ms");
            Console.WriteLine("Koniec zadania 1.");
            Menu();
        }

        public void RemoveElement()
        {

            int userNumber = 0;
            Console.WriteLine($"Podaj indeks, do usunięcia < maks {count + 1}");
            Int32.TryParse(Console.ReadLine(), out userNumber);
           
            int iterations = 100;
            for (int i = 0; i < iterations; i++)
            {
                sterta = new int[count];
                size = 0;
                if (VariablesManager.IsManual)
                {
                    for (int j = 0; j < count -1; j++)
                    {

                        sterta[size] = VariablesManager.Array[j];
                        size++;

                        int index = size - 1;
                        while (index != 0 && sterta[index] > sterta[Parent(index)])
                        {
                            ChangePlace(index, Parent(index));
                            index = Parent(index);
                        }

                    }
                   
                    sw.Restart();
                    sterta[userNumber] = sterta[size - 1];
                    
                    Heapify(userNumber);
                    sw.Stop();

                }
                else
                {
                    for (int j = 0; j < count -1; j++)
                    {

                        sterta[size] = rnd.Next(maxValue);
                        size++;

                        int index = size - 1;
                        while (index != 0 && sterta[index] > sterta[Parent(index)])
                        {
                            ChangePlace(index, Parent(index));
                            index = Parent(index);
                        }

                    }
                    
                    sw.Restart();
                    sterta[userNumber] = sterta[size - 1];
                    Heapify(userNumber);
                    sw.Stop();

                }
                
                
              
                times[i] = sw.Elapsed.TotalMilliseconds * 1000000;
            }
            
            Console.WriteLine($"Czas najmniejszy: {times.Min()} ms, czas najwiekszy: {times.Max()} ms, czas średni: {times.Average()} ms");
            Console.WriteLine("Koniec zadania 1.");
            Menu();
        }
      
        /// <summary>
        /// Układa na nowo elkementy po usunięciu jednego z nich
        /// </summary>
        /// <param name="index"></param>
        private void Heapify(int index)
        {
            int leftChild = LeftChild(index);
            int rightChild = RightChild(index);
            int largest = index;

            if (leftChild < size && sterta[leftChild] > sterta[largest])
            {
                largest = leftChild;
            }

            if (rightChild < size && sterta[rightChild] > sterta[largest])
            {
                largest = rightChild;
            }

            if (largest != index)
            {
                ChangePlace(index, largest);
                Heapify(largest);
            }
        }

        /// <summary>
        /// Wyszukuje liczby w drzewie
        /// </summary>
        /// <param name="value"></param>
        public void Find()
        {   int userNumber = 0;
                Console.WriteLine($"Podaj liczbe ,którą szukasz w kolekcji (liczby sa wygenerowane randomowo)");
                Int32.TryParse(Console.ReadLine(), out userNumber);
            int iterations = 100;
            for (int i = 0; i < iterations; i++)
            {
                sterta = new int[count];
                size = 0;
                for (int j = 0; j < count - j; j++)
                {

                    sterta[size] = rnd.Next(maxValue);
                    size++;

                    int index = size - 1;
                    while (index != 0 && sterta[index] > sterta[Parent(index)])
                    {
                        ChangePlace(index, Parent(index));
                        index = Parent(index);
                    }

                }
                
                bool found = false;
                
                sw.Restart();
                for (int k = 0; k < size; k++)
                {
                    if (sterta[k] == userNumber)
                    {
                        found = true;
                        //MainMenu.ColorizeString($"Liczba {userNumber} znaleziona na indeksie {k}");
                    }
                }
                sw.Stop();
                if (found == false)
                {
                   // MainMenu.ColorizeString($"Liczba {userNumber} nie znaleziona");
                };
                times[i] = sw.Elapsed.TotalMilliseconds * 1000000;
            }
            Console.WriteLine($"Czas najmniejszy: {times.Min()} ms, czas najwiekszy: {times.Max()} ms, czas średni: {times.Average()} ms");
            Console.WriteLine("Koniec zadania 1.");
            Menu();
        }

        public void Display()
        {
            bool firstTail = true;
            Display(0, "", true, firstTail);
            sterta = new int[count];
            size = 0;
            MainMenu.ColorizeString("Dane wyzerowane, by wyswietlić strukturę kolejny raz, nalezy ponowić którkolwiek operację", ConsoleColor.Red);
            Menu();
        }

        private void Display(int index, string prefix, bool isTail, bool firsttail)
        {
            Console.WriteLine(prefix + (firsttail? "":(isTail ? "└── " : "├── ")) + sterta[index]+$" ( indeks {index})");

            int leftChild = LeftChild(index);
            int rightChild = RightChild(index);

            if (leftChild < size)
            {
                Display(leftChild, prefix + (isTail ? "    " : "│   "), rightChild >= size, false);
            }

            if (rightChild < size)
            {
                Display(rightChild, prefix + (isTail ? "    " : "│   "), true, false);
            }
        }

    }
}
