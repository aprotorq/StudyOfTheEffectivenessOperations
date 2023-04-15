using StudyOfTheEffectivenessOperations.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace StudyOfTheEffectivenessOperations.Operation.LinkedListOperation
{
    public class LinkedListOperation
    {
        private LinkedList<int> lista;
        private int numberCount;
        private int numberCountToRemove;
        private Random random= new Random();
        private Stopwatch sw = Stopwatch.StartNew();
        private double[] times = new double[100];
        public LinkedList<int> Lista { get => lista; set => lista = value; }
        public int NumberCount { get => numberCount; set => numberCount = value; }
        public int NumberCountToRemove { get => numberCountToRemove; set => numberCountToRemove = value; }

        public LinkedListOperation()
        {
            NumberCount = VariablesManager.RandomNumberCount;
            NumberCountToRemove = VariablesManager.NumberCountToRemove;
            // Tworzenie nowej pustej listy dwukierunkowej
            Lista = new LinkedList<int>();
            Menu();
        }
        public void Menu()
        {
            string menu = $"Wybierz numer wskazujący która akcja ma zostać wykonana wykonać na liście. \r\n ";
            menu += "Każda wybrana akcja zostanie powtórzona w pętli 100 razy \r\n ";
            menu += "(za każdym razem zostanie wygenerowany nowy zestaw danych) a czas wykonania uśredniony \r\n ";

            menu += $" ---------------------------\r\n";
            menu += $"[1] dodwanie {NumberCount} losowych liczb w przedziele 0- 1000 000 (x100) do {VariablesManager.QuantityToAutoFill} istniejących\r\n ";
            menu += $"[2] dodwania {NumberCount} losowych liczb w przedziele 0- 1000 000 (x100) na początku listy do {VariablesManager.QuantityToAutoFill} istniejących \r\n ";
            menu += $"[3] dodwania {NumberCount} losowych liczb w przedziale 0- 1000 000 (x100) na końcu listy do {VariablesManager.QuantityToAutoFill} istniejących \r\n ";
            menu += $"[4] dodwania {NumberCount} losowych liczb w przedziele 0- 1000 000 (x100) w losowym miejscu listy do {VariablesManager.QuantityToAutoFill} istniejących \r\n ";
            menu += $"[5] usuwanie {NumberCountToRemove} z początku listy {NumberCount} elementowej \r\n ";
            menu += $"[6] usuwanie {NumberCountToRemove} z końcu listy {NumberCount} elementowej \r\n ";
            menu += $"[7] usuwanie {NumberCountToRemove} z losowo wybranego miejsca listy {NumberCount} elementowej \r\n ";
            menu += $"[8] Wyświetl strukturę \r\n ";

            menu += "--------------------------------------------------- \r\n ";
            menu += "[9] Wyjdź do głównego menu\r\n";

            Console.WriteLine(menu);
            string key = Console.ReadLine();

            switch (key)
            {
                case "1":

                    MainMenu.ColorizeString($"dodwanie {NumberCount} losowych liczb w przedziele 0 - 1000 000(x100) do listy {VariablesManager.QuantityToAutoFill} istniejących\r\n");
                    Run();
                    break;
                case "2":
                    MainMenu.ColorizeString($"dodwania {NumberCount} losowych liczb w przedziele 0- 1000 000 (x100) na początku listy do {VariablesManager.QuantityToAutoFill} istniejących\r\n");
                    AddToBegining();
                    break;
                case "3":
                    MainMenu.ColorizeString($"dodwania {NumberCount} losowych liczb w przedziale 0- 1000 000 (x100) na końcu listy do {VariablesManager.QuantityToAutoFill} istniejących\r\n");
                    AddToEnding();
                    break;
                case "4":
                    MainMenu.ColorizeString($"dodwania {NumberCount} losowych liczb w przedziele 0- 1000 000 (x100) w losowym miejscu listy do {VariablesManager.QuantityToAutoFill} istniejących\r\n");
                    AddToRandom();
                    break;
                case "5":
                    MainMenu.ColorizeString($"usuwanie {NumberCountToRemove} z początku listy  (x100)  {NumberCount} \r\n");
                    RemoveFromStart();
                    break;
                case "6":
                    MainMenu.ColorizeString($"usuwanie {NumberCountToRemove} z końcu listy  (x100)  {NumberCount} \r\n");
                    RemoveFromEnd();
                    break;
                case "7":
                    MainMenu.ColorizeString($"usuwanie {NumberCountToRemove} z losowo wybranego miejsca listy  (x100)  {NumberCount} \r\n");
                    RemoveFromRandom();
                    break;
                case "8":
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
        public void Run()
        {
                AddToBegining();
        }

        public void AddToBegining(int randomNumber = 1)
        {
            times = new double[times.Length];
            lista = new LinkedList<int>();
            for (int i = 0; i < VariablesManager.QuantityToAutoFill; i++)
            {
                lista.AddFirst(random.Next(10000));
            }
            for (int i = 0; i < VariablesManager.Array.Length; i++)
            {
                sw.Restart();
                lista.AddFirst(VariablesManager.Array[i]);
                sw.Stop();
                times[i] = sw.Elapsed.TotalSeconds;
                Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalSeconds} ms");
            }
          }
        public void AddToEnding(int randomNumber = 1)
        {
            times = new double[times.Length];
            lista = new LinkedList<int>();
            for (int i = 0; i < VariablesManager.QuantityToAutoFill; i++)
            {
                lista.AddFirst(random.Next(10000));
            }
            //for(int i = 0;i<100;i++)
            //for (int i = 0; i < VariablesManager.Array.Length; i++)
            //{
            //    sw.Restart();
            //    lista.AddLast(randomNumber);
            //    sw.Stop();
            //    times[i] = sw.Elapsed.TotalSeconds;
            //    Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalSeconds} ms");
            //}
        }
        public void AddToRandom(int randomNumber = 1)
        {
            times = new double[times.Length];
            //for (int i = 0; i < VariablesManager.DefaultQuantityBeforeAddOperation; i++)
            //    {
            //        // Dodawanie nowych elementów w losowym miejscu listy
            //        Random rand = new Random();
            //        int index = rand.Next(0, lista.Count);
            //        LinkedListNode<int> wezel = lista.First;
            //        for (int i = 0; i < index; i++)
            //        {
            //            wezel = wezel.Next;
            //        }
            //        lista.AddAfter(wezel, 15);
            //        sw.Stop();
            //        times[i] = sw.Elapsed.TotalSeconds;
            //        Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalSeconds} ms");
            //    }
        }
        public void RemoveFromStart()
        {
            times = new double[times.Length];
            lista.RemoveFirst(); // Usunięcie pierwszego elementu listy
            sw.Stop();
            //times[i] = sw.Elapsed.TotalSeconds;
            //Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalSeconds} ms");
        }
        public void RemoveFromEnd(int randomNumber = 1) 
        {
            times = new double[times.Length];
            lista.RemoveLast(); // Usunięcie ostatniego elementu listy
            sw.Stop();
            //times[i] = sw.Elapsed.TotalSeconds;
            //Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalSeconds} ms");
        }
        public void RemoveFromRandom(int randomNumber = 1)
        {
            times = new double[times.Length];
            // Usuwanie elementów z listy
            Lista.Remove(20); // Usunięcie elementu o wartości 20
            sw.Stop();
            //times[i] = sw.Elapsed.TotalSeconds;
            //Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalSeconds} ms");
        }
        public void FindElement(int randomNumber = 1)
        {
            times = new double[times.Length];
            // Szukanie elementu na liście
            int poszukiwanaWartosc = 10;
            LinkedListNode<int> wezelSzukany = lista.Find(poszukiwanaWartosc);
            sw.Stop();
            //times[i] = sw.Elapsed.TotalSeconds;
            //Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalSeconds} ms");
            if (wezelSzukany != null)
            {
                Console.WriteLine("Znaleziono element o wartości {0}", wezelSzukany.Value);
            }
            else
            {
                Console.WriteLine("Nie znaleziono elementu o wartości {0}", poszukiwanaWartosc);
            }
        }
        public void Display()
        {
            
            foreach (int element in lista)
            {
                Console.Write(element + " ");
            }
            Menu();
        }
    }
}