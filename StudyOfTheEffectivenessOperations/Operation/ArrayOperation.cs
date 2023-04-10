using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOfTheEffectivenessOperations.Operation.ArrayOperation
{
    public class ArrayOperation
    {
        private int[] array_operation_init;

        public ArrayOperation() {
            Menu();
        }
        public void Menu()
        {
            string menu = "Wybierz numer wskazujący która akcja ma zostać wykonana wykonać na tablicy.";
            menu += Environment.NewLine + "Każda wybrana akcja zostanie powtórzona w pętli 100 razy \r\n (za każdym razem zostanie wygenerowany nowy zestaw danych) a czas wykonania uśredniony";

            menu += Environment.NewLine + "---------------------------";
            menu += Environment.NewLine + "[1] dodwanie 10000 losowych liczb w przedziele 0- 1000 000 (x100)";
            menu += Environment.NewLine + "[2] dodwania 100 losowych liczb w przedziele 0- 1000 000 (x100) na początku tablicy";
            menu += Environment.NewLine + "[3] dodwania 100 losowych liczb w przedziale 0- 1000 000 (x100) na końcu tablicy";
            menu += Environment.NewLine + "[4] dodwania 100 losowych liczb w przedziele 0- 1000 000 (x100) w losowym miejscu tablicy";
            menu += Environment.NewLine + "[5] usuwanie 100 z początku tablicy";
            menu += Environment.NewLine + "[6] usuwanie 100 z końcu tablicy";
            menu += Environment.NewLine + "[7] usuwanie 100 z losowo wybranego miejsca tablicy";

            menu += Environment.NewLine + "---------------------------------------------------";
            menu += Environment.NewLine + "[6] Wyjdź do głównego menu\r\n";

            Console.WriteLine(menu);
            string key = Console.ReadLine();

            switch (key)
            {
                case "1":

                    MainMenu.ColorizeString("dodwanie 100000 losowych liczb w przedziele 0 - 1000 000(x100)\r\n");
                    AddToArray();
                    break;
                case "2":
                    MainMenu.ColorizeString("dodwania 100000 losowych liczb w przedziele 0- 1000 000 (x100) na początku tablicy\r\n");
                    AddToArraAtZeroIndexy();
                    break;
                case "3":
                    MainMenu.ColorizeString("dodwania 100000 losowych liczb w przedziale 0- 1000 000 (x100) na końcu tablicy\r\n");
                    AddToArraAtAtTheEnd();
                    break;
                case "4":
                    MainMenu.ColorizeString("dodwania 100000 losowych liczb w przedziele 0- 1000 000 (x100) w losowym miejscu tablicy\r\n");
                    AddToArraAtAtRandomIndex();
                    break;
                case "5":
                    MainMenu.ColorizeString("usuwanie 100 z początku tablicy  (x100) \r\n");
                    RemoveNumberFromFirtsIndexOfArray();
                    break;
                case "6":
                    MainMenu.ColorizeString("usuwanie 100 z końcu tablicy  (x100) \r\n");
                    RemoveNumberFromLastIndexOfArray();
                    break;
                case "7":
                    MainMenu.ColorizeString("usuwanie 100 z losowo wybranego miejsca tablicy  (x100) \r\n");
                    RemoveNumberFromRadnomIndexOfArray();
                    break;
                case "8":
                    MainMenu.ShowMenu();
                    break;
                default:
                    Menu();
                    break;
            }
        }
        /// <summary>
        /// Tworzenie nowej tablicy z lsoowcyh elementów
        /// </summary>
        public void AddToArray() {

            double[] times = new double[100];
            int iterations = 100;
            int elements = 100000;
            int[] arr = new int[0];// tworzymy nową pustą tablicę
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < iterations; i++)
            {
                sw.Restart();

                for (int j = 0; j < elements; j++)
                {
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length - 1] = rnd.Next(100000);
                }

                sw.Stop();
                times[i] = sw.Elapsed.TotalSeconds;
                Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalSeconds} ms");
                arr = new int[0];// tworzymy nową pustą tablicę przed każdą iteracją
            }
            Console.WriteLine(times.Average());
            Console.WriteLine("Koniec zadania 1.");
        }
        /// <summary>
        /// dodawane lsoowcyh liczb na pocżatek tablicy
        /// </summary>
        public void AddToArraAtZeroIndexy()
        {

            double[] times = new double[100];
            const int maxValue = 100000;
            int iterations = 100;
            int elements = 100000;
            int[] arr = new int[0];// tworzymy nową pustą tablicę
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < iterations; i++)
            {
                sw.Restart();
                // Dodaj losowe liczby do tablicy na początku

                for (int j = 0; j < elements; j++)
                {
                    // Zwiększanie rozmiaru tablicy o 1
                    Array.Resize(ref arr, arr.Length + 1);
                    for (int k = arr.Length - 1; k > 0; k--)
                    {
                        arr[k] = arr[k - 1];
                    }
                    arr[0] = rnd.Next(maxValue);
                }

                sw.Stop();
                times[i] = sw.Elapsed.TotalSeconds;
                Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalSeconds} sec");
                arr = new int[0];// tworzymy nową pustą tablicę przed każdą iteracją
            }
            Console.WriteLine(times.Average());
            Console.WriteLine("Koniec zadania 2.");
        }
        /// <summary>
        /// dodawane lsoowcyh liczb na koniec tablicy
        /// </summary>
        public void AddToArraAtAtTheEnd()
        {
            double[] times = new double[100];
            const int maxValue = 100000;
            int iterations = 100;
            int elements = 100000;
            int[] arr = new int[0];// tworzymy nową pustą tablicę
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();
            // Powtarzanie operacji
            for (int i = 0; i < iterations; i++)
            {
                // Generowanie losowych liczb i dodawanie ich na końcu tablicy
                sw.Restart();
                for (int j = 0; j < elements; j++)
                {
                    // Zwiększanie rozmiaru tablicy o 1
                    Array.Resize(ref arr, arr.Length + 1);

                    // Dodawanie losowej liczby na końcu
                    arr[arr.Length - 1] = rnd.Next(maxValue);
                }
                sw.Stop();
                times[i] = sw.Elapsed.TotalSeconds;
                Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalSeconds} sec");
                arr = new int[0];// tworzymy nową pustą tablicę przed każdą iteracją
            }
            Console.WriteLine(times.Average());
            Console.WriteLine("Koniec zadania 3.");
        }

        /// <summary>
        /// dodawane lsoowcyh liczb w losowym miejscu tablicy
        /// </summary>
        public void AddToArraAtAtRandomIndex()
        {
            double[] times = new double[100];
            const int maxValue = 100000;
            int iterations = 100;
            int elements = 100000;
            int[] arr = new int[0];// tworzymy nową pustą tablicę
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();
            // Powtarzanie operacji
            for (int i = 0; i < iterations; i++)
            {
                // Generowanie losowych liczb i dodawanie ich na końcu tablicy
                sw.Restart();
                for (int j = 0; j < elements; j++)
                {
                    // Losowanie indeksu w tablicy, w którym ma zostać umieszczona liczba
                    int index = rnd.Next(0, arr.Length + 1);

                    int number = rnd.Next(maxValue);
                    // Zwiększanie rozmiaru tablicy o 1
                    Array.Resize(ref arr, arr.Length + 1);

                    // Przesuwanie elementów tablicy od wybranego indeksu o 1 w prawo
                    for (int k = arr.Length - 1; k > index; k--)
                    {
                        arr[k] = arr[k - 1];
                    }

                    // Umieszczanie wylosowanej liczby w tablicy w losowym miejscu
                    arr[index] = number;
                }
                sw.Stop();
                times[i] = sw.Elapsed.TotalSeconds;
                Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalSeconds} sec");
                arr = new int[0];// tworzymy nową pustą tablicę przed każdą iteracją
            }
            Console.WriteLine(times.Average());
            Console.WriteLine("Koniec zadania 4.");
        }
        public void RemoveNumberFromFirtsIndexOfArray()
        {
            double[] times = new double[100];
            const int maxValue = 1000;
            int iterations = 100;
            int elements = 1000;
            int[] arr = new int[0];// tworzymy nową pustą tablicę
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();

            //100 powtórzeń dla całego algorytmu
            for (int i = 0; i < iterations; i++)
            {
                for (int j = 0; j < elements; j++)
                {
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length - 1] = rnd.Next(maxValue);
                }
                // Usuń pierwszą liczbę z początku tablicy a następnie zmniejsz rozmiar tablicy o 1
                for (int j = 0; j < iterations; j++)
                { 
                    sw.Restart();

                    for (int k = 0; k < arr.Length - 1; k++)
                    {
                        arr[k] = arr[k + 1];
                    }
                    Array.Resize(ref arr, arr.Length - 1);

                    sw.Stop();

                    times[i] = sw.Elapsed.TotalMilliseconds;
                }

                
                
                Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalMilliseconds} sec");
                arr = new int[0];// tworzymy nową pustą tablicę przed każdą iteracją
            }
            Console.WriteLine("średni czas: "+times.Average().ToString()+" sec");
            Console.WriteLine("Koniec zadania 5.");

        }

        public void RemoveNumberFromLastIndexOfArray()
        {
            double[] times = new double[100];
            const int maxValue = 1000;
            int iterations = 100;
            int elements = 1000;
            int[] arr = new int[0];// tworzymy nową pustą tablicę
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();

            //100 powtórzeń dla całego algorytmu
            for (int i = 0; i < iterations; i++)
            {
                for (int j = 0; j < elements; j++)
                {
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length - 1] = rnd.Next(maxValue);
                }
                // Usuń liczbę z końca tablicy a następnie zmniejsz rozmiar tablicy o 1
                for (int j = 0; j < iterations; j++)
                {
                    sw.Restart();

                    Array.Resize(ref arr, arr.Length - 1);

                    sw.Stop();

                    times[i] = sw.Elapsed.TotalMilliseconds;
                }



                Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalMilliseconds * 1000000} ns");
                arr = new int[0];// tworzymy nową pustą tablicę przed każdą iteracją
            }
            Console.WriteLine("średni czas: " + times.Average().ToString() + " ns");
            Console.WriteLine("Koniec zadania 6.");

        }

        public void RemoveNumberFromRadnomIndexOfArray()
        {
            double[] times = new double[100];
            const int maxValue = 1000;
            int iterations = 100;
            int elements = 1000;
            int[] arr = new int[0];// tworzymy nową pustą tablicę
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();

            //100 powtórzeń dla całego algorytmu
            for (int i = 0; i < iterations; i++)
            {
                for (int j = 0; j < elements; j++)
                {
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length - 1] = rnd.Next(maxValue);
                }
                // Usuń liczbę z końca tablicy a następnie zmniejsz rozmiar tablicy o 1
                for (int j = 0; j < iterations; j++)
                {
                    int indexToRemove = rnd.Next(0, arr.Length); // losowy indeks do usunięcia
                    sw.Restart();
                    for (int k = indexToRemove; k < arr.Length - 1; k++)
                    {
                        arr[k] = arr[k + 1];
                    }

                    Array.Resize(ref arr, arr.Length - 1);

                    sw.Stop();

                    times[i] = sw.Elapsed.TotalMilliseconds;
                }
                
               
                Array.Resize(ref arr, arr.Length - 1); // zmniejszenie rozmiaru tablicy


                Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalMilliseconds * 1000000} ns");
                arr = new int[0];// tworzymy nową pustą tablicę przed każdą iteracją
            }
            Console.WriteLine("średni czas: " + times.Average().ToString() + " ns");
            Console.WriteLine("Koniec zadania 6.");

        }
    }
}

