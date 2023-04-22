using StudyOfTheEffectivenessOperations.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace StudyOfTheEffectivenessOperations.Operation.LinkedListOperation
{
    public class LinkedListOperation
    {
        private LinkedList<int> lista;
        private int numberCount;
        private int numberCountToRemove;
        public Random rnd= new Random();
        private Stopwatch sw = Stopwatch.StartNew();
        private double[] times = new double[100];
        public int count;
        const int maxValue = 100000;
        public LinkedList<int> Lista { get => lista; set => lista = value; }
        public int NumberCount { get => numberCount; set => numberCount = value; }
        public int NumberCountToRemove { get => numberCountToRemove; set => numberCountToRemove = value; }

        public LinkedListOperation()
        {
            NumberCount = VariablesManager.RandomNumberCount;
            NumberCountToRemove = VariablesManager.NumberCountToRemove;
            // Tworzenie nowej pustej listy dwukierunkowej
            count = VariablesManager.IsManual == true ? VariablesManager.Array.Length : VariablesManager.QuantityToAutoFill;

            Lista = new LinkedList<int>();
            Menu();
        }
        public void Menu()
        {
            string menu = $"\r\nWybierz numer wskazujący która akcja ma zostać wykonana wykonać na liście. \r\n ";
            menu += "Każda wybrana akcja zostanie powtórzona w pętli 100 razy \r\n ";
            menu += "(za każdym razem zostanie wygenerowany nowy zestaw danych) a czas wykonania uśredniony \r\n ";

            menu += $" ---------------------------\r\n";
            menu += $"[1] dodwania {NumberCount} losowych liczb w przedziele 0- 1000 000 (x100) na początku listy do {VariablesManager.QuantityToAutoFill} istniejących \r\n ";
            menu += $"[2] dodwania {NumberCount} losowych liczb w przedziale 0- 1000 000 (x100) na końcu listy do {VariablesManager.QuantityToAutoFill} istniejących \r\n ";
            menu += $"[3] dodwania {NumberCount} losowych liczb w przedziele 0- 1000 000 (x100) w losowym miejscu listy do {VariablesManager.QuantityToAutoFill} istniejących \r\n ";
            menu += $"[4] usuwanie {NumberCountToRemove} z początku listy {NumberCount} elementowej \r\n ";
            menu += $"[5] usuwanie {NumberCountToRemove} z końcu listy {NumberCount} elementowej \r\n ";
            menu += $"[6] usuwanie {NumberCountToRemove} z losowo wybranego miejsca listy {NumberCount} elementowej \r\n ";
            menu += $"[7] wyszukaj na liście \r\n ";
            menu += $"[8] Wyświetl strukturę \r\n ";

            menu += "--------------------------------------------------- \r\n ";
            menu += "[9] Wyjdź do głównego menu\r\n";

            Console.WriteLine(menu);
            string key = Console.ReadLine();

            switch (key)
            {
                
                case "1":
                    MainMenu.ColorizeString($"dodwania {NumberCount} losowych liczb w przedziele 0- 1000 000 (x100) na początku listy do {VariablesManager.QuantityToAutoFill} istniejących\r\n");
                    AddToBegining();
                    break;
                case "2":
                    MainMenu.ColorizeString($"dodwania {NumberCount} losowych liczb w przedziale 0- 1000 000 (x100) na końcu listy do {VariablesManager.QuantityToAutoFill} istniejących\r\n");
                    AddToEnding();
                    break;
                case "3":
                    MainMenu.ColorizeString($"dodwania {NumberCount} losowych liczb w przedziele 0- 1000 000 (x100) w losowym miejscu listy do {VariablesManager.QuantityToAutoFill} istniejących\r\n");
                    AddToRandom();
                    break;
                case "4":
                    MainMenu.ColorizeString($"usuwanie {NumberCountToRemove} z początku listy  (x100)  {NumberCount} \r\n");
                    RemoveFromStart();
                    break;
                case "5":
                    MainMenu.ColorizeString($"usuwanie {NumberCountToRemove} z końcu listy  (x100)  {NumberCount} \r\n");
                    RemoveFromEnd();
                    break;
                case "6":
                    MainMenu.ColorizeString($"usuwanie {NumberCountToRemove} z losowo wybranego miejsca listy  (x100)  {NumberCount} \r\n");
                    RemoveFromRandom();
                    break;
                case "7":
                    MainMenu.ColorizeString($"wyszukiwanie elementu listy  (x100)  {NumberCount} \r\n");
                    FindElement();
                    break;
                case "8":
                    MainMenu.ColorizeString($"wyświetlam strukturę\r\n");
                    Display();
                    break;
                case "9":
                    MainMenu.ShowMenu();
                    break;
                default:
                    Menu();
                    break;
            }
        }

        public void AddToBegining()
        {
            times = new double[times.Length];
            lista = new LinkedList<int>();
            int iterations = 100;
            for (int i = 0; i < iterations; i++)
            {
                if (VariablesManager.IsManual)
                {
                    sw.Restart();
                    for (int j = 0; j < count; j++)
                    {
                        lista.AddFirst(VariablesManager.Array[j]);
                    }
                    sw.Stop();
                }
                else 
                {
                    sw.Restart();
                    for (int j = 0; j < count; j++)
                    {
                        lista.AddFirst(rnd.Next());
                    } 
                    sw.Stop();
                }
                times[i] = sw.Elapsed.TotalMilliseconds;
                Console.WriteLine($"Czas najmniejszy: {times.Min()} ms, czas najwiekszy: {times.Max()} ms, czas średni: {times.Average()} ms");
                Console.WriteLine("Koniec zadania 1.");
            }
            Menu();
        }
          
        public void AddToEnding()
        {
            times = new double[times.Length];
            lista = new LinkedList<int>();
            int iterations = 100;
            for (int i = 0; i < iterations; i++)
            {
                if (VariablesManager.IsManual)
                {
                    sw.Restart();
                    for (int j = 0; j < count; j++)
                    {
                        lista.AddLast(VariablesManager.Array[j]);
                    }
                    sw.Stop();
                }
                else
                {
                    sw.Restart();
                    for (int j = 0; j < count; j++)
                    {
                        lista.AddLast(rnd.Next());
                    }
                    sw.Stop();
                }
                times[i] = sw.Elapsed.TotalMilliseconds;
                Console.WriteLine($"Czas najmniejszy: {times.Min()} ms, czas najwiekszy: {times.Max()} ms, czas średni: {times.Average()} ms");
                Console.WriteLine("Koniec zadania 2.");
            }
            Menu();
        }
        public void AddToRandom()
        {
            times = new double[times.Length];
            lista = new LinkedList<int>();
            int userIndex = 0;
            if (VariablesManager.IsManual)
            {
                Console.WriteLine("Podaj inseks na liście, na jakim ma zostać dodana liczba");
                Int32.TryParse(Console.ReadLine(), out userIndex);
                if (userIndex > count)
                {
                    Console.WriteLine($"Indeks jest większy niż wielkość listy ({count}), podaj mniejszy");
                    Int32.TryParse(Console.ReadLine(), out userIndex);
                }
            }
            int iterations = 100;
            for (int i = 0; i < iterations; i++)
            {
                if (VariablesManager.IsManual)
                {   
                    for (int j = 0; j < count; j++)
                    {
                        lista.AddLast(VariablesManager.Array[j]);
                    }

                    int randomNumber = rnd.Next(maxValue);
                    
                    LinkedListNode<int> node = lista.First;
                   
                    for (int j = 0; j < userIndex; j++)
                    {
                        node = node.Next;
                    }
                    sw.Restart();
                    lista.AddAfter(node, randomNumber);
                    sw.Stop();
                }

                else
                {
                    for (int j = 0; j < count; j++)
                    {
                        lista.AddLast(rnd.Next(maxValue));
                    }
                   
                    int randomNumber = rnd.Next(maxValue);
                    

                    int randomIndex = rnd.Next(0, lista.Count);
                    LinkedListNode<int> node = lista.First;

                    for (int j = 0; j < randomIndex; j++)
                    {
                        node = node.Next;
                    }
                    sw.Restart();
                    lista.AddAfter(node, randomNumber);
                    sw.Stop();
                }
                times[i] = sw.Elapsed.TotalMilliseconds;
                
            }
            Console.WriteLine($"Czas najmniejszy: {times.Min()} ms, czas najwiekszy: {times.Max()} ms, czas średni: {times.Average()} ms");
            Console.WriteLine("Koniec zadania 3.");
            Menu();
        }
        public void RemoveFromStart()
        {
            times = new double[times.Length];
            lista = new LinkedList<int>();
            int iterations = 100;
            for (int i = 0; i < iterations; i++)
            {
                if (VariablesManager.IsManual)
                {

                    for (int j = 0; j < count; j++)
                    {
                        lista.AddLast(VariablesManager.Array[j]);
                    }
                    sw.Restart();
                    lista.RemoveFirst(); // Usunięcie pierwszego elementu listy
                    sw.Stop();
                }
                else
                {
                    for (int j = 0; j < count; j++)
                    {
                        lista.AddLast(rnd.Next(maxValue));
                    }
                    sw.Restart();
                    lista.RemoveFirst(); // Usunięcie pierwszego elementu listy
                    sw.Stop();
                    
                }
                times[i] = sw.Elapsed.TotalMilliseconds * 1000000;
                MainMenu.ColorizeString($"Czas najmniejszy: {times.Min()} ns, czas najwiekszy: {times.Max() } ns, czas średni: {times.Average() } ns",ConsoleColor.DarkYellow);
                Console.WriteLine("\r\nKoniec zadania 4.");
            }
            Menu();

            //Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalSeconds} ms");
        }
        public void RemoveFromEnd() 
        {
            times = new double[times.Length];
            lista = new LinkedList<int>();
            int iterations = 100;
            for (int i = 0; i < iterations; i++)
            {
                if (VariablesManager.IsManual)
                {

                    for (int j = 0; j < count; j++)
                    {
                        lista.AddLast(VariablesManager.Array[j]);
                    }
                    sw.Restart();
                    lista.RemoveLast(); // Usunięcie ostatniego elementu listy
                    sw.Stop();
                }
                else
                {
                    for (int j = 0; j < count; j++)
                    {
                        lista.AddLast(rnd.Next(maxValue));
                    }
                    sw.Restart();
                    lista.RemoveLast(); // Usunięcie ostatnieego elementu listy
                    sw.Stop();

                }
                times[i] = sw.Elapsed.TotalMilliseconds * 1000000;
                MainMenu.ColorizeString($"Czas najmniejszy: {times.Min()} ns, czas najwiekszy: {times.Max()} ns, czas średni: {times.Average()} ns", ConsoleColor.DarkYellow);
                Console.WriteLine("\r\nKoniec zadania 5.");
            }
            Menu();
        }
        public void RemoveFromRandom()
        {
            times = new double[times.Length];
            lista = new LinkedList<int>();
            int userIndex = 0;
            if (VariablesManager.IsManual)
            {
                Console.WriteLine("Podaj indeks, który chcesz usunąć");
                Int32.TryParse(Console.ReadLine(), out userIndex);
                if (userIndex > count)
                {
                    Console.WriteLine($"Indeks jest większy niż wielkość listy ({count}), podaj mniejszy");
                    Int32.TryParse(Console.ReadLine(), out userIndex);
                }
            }
            int iterations = 100;
            for (int i = 0; i < iterations; i++)
            {
                if (VariablesManager.IsManual)
                {
                    for (int j = 0; j < count; j++)
                    {
                        lista.AddLast(VariablesManager.Array[j]);
                    }

                    sw.Restart();
                    LinkedListNode<int> nodeToRemove = lista.First;

                    for (int j = 0; j < userIndex; i++)
                    {
                        nodeToRemove = nodeToRemove.Next;
                    }

                    lista.Remove(nodeToRemove);

                    
                    sw.Stop();
                }

                else
                {
                    for (int j = 0; j < count; j++)
                    {
                        lista.AddLast(rnd.Next(maxValue));
                    }

                    sw.Restart();
                    LinkedListNode<int> nodeToRemove = lista.First;

                    for (int j = 0; j < userIndex; i++)
                    {
                        nodeToRemove = nodeToRemove.Next;
                    }

                    lista.Remove(nodeToRemove);


                    sw.Stop();
                }
                times[i] = sw.Elapsed.TotalMilliseconds;

            }
            Console.WriteLine($"Czas najmniejszy: {times.Min()} ms, czas najwiekszy: {times.Max()} ms, czas średni: {times.Average()} ms");
            Console.WriteLine("Koniec zadania 6.");
            Menu();
        }
        public void FindElement()
        {
            times = new double[times.Length];
            // Szukanie elementu na liście
            int poszukiwanaWartosc = 0;
            int iterations = 100;

            if (VariablesManager.IsManual)
            {
                for (int i = 0; i < count; i++) { Console.Write(VariablesManager.Array[i] + ","); }
                Console.WriteLine("\r\nPodaj którą chcesz wyszukać");
                Int32.TryParse(Console.ReadLine(), out poszukiwanaWartosc);
            }
            else
            {
                Console.WriteLine("\r\nPodaj którą chcesz wyszukać");
                Int32.TryParse(Console.ReadLine(), out poszukiwanaWartosc);
            }
            for (int i = 0; i < iterations; i++)
            {
                if (VariablesManager.IsManual)
                {
                    sw.Restart();
                    LinkedListNode<int> wezelSzukany = lista.Find(poszukiwanaWartosc);
                    sw.Stop();

                    if (wezelSzukany != null)
                    {
                        Console.WriteLine($"Znaleziono element o wartości {wezelSzukany.Value}");

                    }
                    else
                    {
                        Console.WriteLine($"Nie znaleziono elementu o wartości {poszukiwanaWartosc}" );
                    }
                }
                else
                {
                    poszukiwanaWartosc = rnd.Next();
                    Console.WriteLine($"\r\nWyszukuję {poszukiwanaWartosc}\r\n");
                    sw.Restart();
                    LinkedListNode<int> wezelSzukany = lista.Find(poszukiwanaWartosc);
                    sw.Stop();

                    if (wezelSzukany != null)
                    {
                        Console.WriteLine($"Znaleziono element o wartości {wezelSzukany.Value}");

                    }
                    else
                    {
                        Console.WriteLine($"Nie znaleziono elementu o wartości {poszukiwanaWartosc}");
                    }
                }
                times[i] = sw.Elapsed.TotalMilliseconds;
             
            }
            Console.WriteLine($"Czas najmniejszy: {times.Min()} ms, czas najwiekszy: {times.Max()} ms, czas średni: {times.Average()} ms");
            Console.WriteLine("Koniec zadania 7.");
            Menu();
        }
        public void Display()
        {
            
            foreach (int element in lista)
            {
                Console.Write(element + ", ");
            }
            Menu();
        }
    }
}