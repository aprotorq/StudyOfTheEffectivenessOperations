using StudyOfTheEffectivenessOperations.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace StudyOfTheEffectivenessOperations.Operation.ArrayOperation
{
    public class ArrayOperation
    {
        private int numberCount;
        private int numberCountToRemove;
        private Stopwatch sw = Stopwatch.StartNew();
        private Random rnd = new Random();
        public int count;


        public int NumberCount { get => numberCount; set => numberCount = value; }
        public int NumberCountToRemove { get => numberCountToRemove; set => numberCountToRemove = value; }

        public ArrayOperation() {
            NumberCount = VariablesManager.RandomNumberCount;
            NumberCountToRemove = VariablesManager.NumberCountToRemove;
            count = VariablesManager.IsManual == true ? VariablesManager.Array.Length : VariablesManager.QuantityToAutoFill;
            Menu();
        }
        public void Menu()
        {
            string menu = $"Wybierz numer wskazujący która akcja ma zostać wykonana wykonać na tablicy. \r\n";
            menu += "Każda wybrana akcja zostanie powtórzona w pętli 100 razy \r\n ";
            menu += "(za każdym razem zostanie wygenerowany nowy zestaw danych - nie dla testu manualnego) a czas wykonania uśredniony \r\n";
            menu += $"W przypadku operacji dodawania, najpierw zostanie wygenerowanych {VariablesManager.QuantityToAutoFill} liczb a dopiero potem eksperymenty \r\n";
            menu += $"----------------------------\r\n";
            menu += $"[1] dodwanie {NumberCount} losowych liczb w przedziele 0- 1000 000 (x100) do {VariablesManager.QuantityToAutoFill} istniejących \r\n";
            menu += $"[2] dodwania {NumberCount} losowych liczb w przedziele 0- 1000 000 (x100) na początku tablicy do {VariablesManager.QuantityToAutoFill} istniejących\r\n";
            menu += $"[3] dodwania {NumberCount} losowych liczb w przedziale 0- 1000 000 (x100) na końcu tablicy do {VariablesManager.QuantityToAutoFill} istniejących\r\n";
            menu += $"[4] dodwania {NumberCount} losowych liczb w przedziele 0- 1000 000 (x100) w losowym miejscu tablicy do {VariablesManager.QuantityToAutoFill} istniejących\r\n";
            menu += $"[5] usuwanie {NumberCountToRemove} z początku tablicy {NumberCount} \r\n";
            menu += $"[6] usuwanie {NumberCountToRemove} z końcu tablicy {NumberCount} \r\n";
            menu += $"[7] usuwanie {NumberCountToRemove} z losowo wybranego miejsca tablicy {NumberCount} elementowej\r\n";
            menu += $"[8] wyszukiwanie w tablicy\r\n";
            menu += "--------------------------------------------------- \r\n";
            menu += "[9] Wyjdź do głównego menu\r\n";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(menu); 
            Console.ForegroundColor = ConsoleColor.White;
            string key = Console.ReadLine();

            switch (key)
            {
                case "1":

                    MainMenu.ColorizeString($"dodwanie {NumberCount} losowych liczb w przedziele 0 - 1000 000(x100)\r\n");
                    AddToArray();
                    break;
                case "2":
                    MainMenu.ColorizeString($"dodwania {NumberCount} losowych liczb w przedziele 0- 1000 000 (x100) na początku tablicy\r\n");
                    AddToArraAtZeroIndex();
                    break;
                case "3":
                    MainMenu.ColorizeString($"dodwania {NumberCount} losowych liczb w przedziale 0- 1000 000 (x100) na końcu tablicy\r\n");
                    AddToArraAtAtTheEnd();
                    break;
                case "4":
                    MainMenu.ColorizeString($"dodwania {NumberCount} losowych liczb w przedziele 0- 1000 000 (x100) w losowym miejscu tablicy\r\n");
                    AddToArraAtAtRandomIndex();
                    break;
                case "5":
                    MainMenu.ColorizeString($"usuwanie {NumberCountToRemove} z początku tablicy  (x100) \r\n");
                    RemoveNumberFromFirtsIndexOfArray();
                    break;
                case "6":
                    MainMenu.ColorizeString($"usuwanie {NumberCountToRemove} z końcu tablicy  (x100) \r\n");
                    RemoveNumberFromLastIndexOfArray();
                    break;
                case "7":
                    MainMenu.ColorizeString($"usuwanie {NumberCountToRemove} z losowo wybranego miejsca tablicy  (x100) \r\n");
                    RemoveNumberFromRadnomIndexOfArray();
                    break;
                case "8":
                    MainMenu.ColorizeString($"wyszukaj liczbę w tablicy(x100) \r\n");
                    FindNumberInArray();
                    break;
                case "9":
                    MainMenu.ShowMenu();
                    break;
                default:
                    Menu();
                    break;
            }
        }

        public void FindNumberInArray()
        {
            Console.Clear();
            int userNumber = 0;
            if (VariablesManager.IsManual)
            {

                for (int i = 0; i < count; i++) { Console.Write(VariablesManager.Array[i] + ","); }
                Console.WriteLine("\r\nPodaj którą chcesz wyszukać");
                Int32.TryParse(Console.ReadLine(), out userNumber);
            }
            else
            {
                Console.WriteLine("\r\nPodaj którą chcesz wyszukać");
                Int32.TryParse(Console.ReadLine(), out userNumber);
            }
            double[] times = new double[100];
            int iterations = 100;
            int[] arr = new int[0];// tworzymy nową pustą tablicę
            Console.WriteLine("Czekaj...");
            // Powtarzanie operacji
            for (int i = 0; i < iterations; i++)
            {

                if (VariablesManager.IsManual)
                {
                    arr = new int[count];
                    arr = VariablesManager.Array;
                    for(int j = 0; j < count; j++)
                    {
                        Console.Write(arr[j]+",");
                    }

                    sw.Restart();

                    int n = arr.Length;
                    string finded = string.Empty;
                    for (int j = 0; j < n; j++)
                    {
                        if (arr[j] == userNumber)
                        {
                            finded =  $"\r\nLiczba {userNumber} istnieje w tablicy pod indeksem {j}";

                        }
                    };
                    if (finded.Equals(string.Empty))
                        MainMenu.ColorizeString($"\r\nLiczba {userNumber} nie istnieje w talbicy");
                    else MainMenu.ColorizeString(finded);

                    sw.Stop();
                }
                else
                {
                    arr = new int[count];
                    for (int j = 0; j < count; j++)
                    {
                        arr[j] = rnd.Next(count);
                    }
                    Console.WriteLine("Poniżej wyswietlona zostaje tablica z liczbami do testu\r\n");
                    for (int j = 0; j < count; j++)
                    {
                        Console.Write(arr[j] + ",");
                    }
                    sw.Restart();
                    int n = arr.Length;
                    string finded = string.Empty;
                    for (int j = 0; j < n; j++)
                    {
                        if (arr[j] == userNumber)
                        {
                            finded = $"\r\nLiczba {userNumber} istnieje w tablicy pod indeksem {j}\r\n";

                        }
                    };
                    if (finded.Equals(string.Empty))
                        MainMenu.ColorizeString($"\r\nLiczba {userNumber} nie istnieje w talbicy");
                    else MainMenu.ColorizeString(finded);
                    sw.Stop();
                }

                times[i] = sw.Elapsed.TotalMilliseconds;
                Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalMilliseconds} ms");
                arr = new int[0];// tworzymy nową pustą tablicę przed każdą iteracją
            }
            Console.Clear();
            Console.WriteLine($"Czas najmniejszy: {times.Min()}, czas najwiekszy: {times.Max()}, czas średni: {times.Average()} ms");
            Console.WriteLine("Koniec zadania 1.");
            Menu();
        }

        /// <summary>
        /// Tworzenie nowej tablicy z lsoowcyh elementów
        /// </summary>
        public void AddToArray() {
            Console.Clear();
            double[] times = new double[100];
            const int maxValue = 100000;
            int iterations = 100;
            int[] arr = new int[0];// tworzymy nową pustą tablicę
            Console.WriteLine("Czekaj...");
            for (int i = 0; i < iterations; i++)
            {

                if (VariablesManager.IsManual)
                { 
                    sw.Restart();
                    for (int j = 0; j < count; j++)
                    {

                        Array.Resize(ref arr, arr.Length + 1);

                       
                        arr[arr.Length - 1] = VariablesManager.Array[j];
                      
                    } 
                  sw.Stop();
                }
                else 
                {
                    arr = new int[count];
                    for (int j = 0; j < count; j++)
                    {
                        arr[j] = rnd.Next(count);
                    }
                    sw.Restart();
                    
                    for (int j = 0; j < count; j++)
                    {

                        Array.Resize(ref arr, arr.Length + 1);

                       
                        arr[arr.Length - 1] = rnd.Next(maxValue);
                       
                    }
                    sw.Stop();
                } 

                times[i] = sw.Elapsed.TotalMilliseconds;
                //Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalMilliseconds} ms");
                arr = new int[0];// tworzymy nową pustą tablicę przed każdą iteracją
            }
            Console.Clear();
            Console.WriteLine($"Czas najmniejszy: {times.Min()}, czas najwiekszy: {times.Max()}, czas średni: {times.Average()} ms");
            Console.WriteLine("Koniec zadania 1.");
            Menu();

        }
        /// <summary>
        /// dodawane lsoowcyh liczb na pocżatek tablicy
        /// </summary>
        public void AddToArraAtZeroIndex()
        {
            Console.Clear();

            double[] times = new double[100];
            const int maxValue = 100000;
            int iterations = 100;
            int[] arr = new int[0];// tworzymy nową pustą tablicę
            Console.WriteLine("Czekaj...");

            for (int i = 0; i < iterations; i++)
            {
                
                
                // Dodaj losowe liczby do tablicy na początku
                //jeśli wybrany zostanie zestaw testowy (wczyt z pliku)

                if (VariablesManager.IsManual)
                {
                   sw.Restart();
                    for (int j = 0; j < count; j++)
                    {

                        Array.Resize(ref arr, arr.Length + 1);
                        for (int k = arr.Length - 1; k > 0; k--)
                        {
                            arr[k] = arr[k - 1];
                        }
                        arr[0] = VariablesManager.Array[j];
                    }
                    sw.Stop();
                }
                else
                {
                    arr = new int[VariablesManager.QuantityToAutoFill];
                    for (int j = 0; j < VariablesManager.QuantityToAutoFill; j++)
                    {
                        arr[j] = rnd.Next(maxValue);
                    }
                    sw.Restart();

                    for (int j = 0; j < count; j++)
                    {

                        Array.Resize(ref arr, arr.Length + 1);
                        for (int k = arr.Length - 1; k > 0; k--)
                        {
                            arr[k] = arr[k - 1];
                        }

                        arr[0] = rnd.Next(maxValue);

                    }
                    sw.Stop();
                }
                

               
                times[i] = sw.Elapsed.TotalMilliseconds;
                //Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalSeconds} sec");
                arr = new int[0];// tworzymy nową pustą tablicę przed każdą iteracją
            }
            Console.Clear();
            Console.WriteLine($"Czas najmniejszy: {times.Min()}, czas najwiekszy: {times.Max()}, czas średni: {times.Average()} ms");
            Console.WriteLine("Koniec zadania 2.");
            Menu();

        }
        /// <summary>
        /// dodawane lsoowcyh liczb na koniec tablicy
        /// </summary>
        public void AddToArraAtAtTheEnd()
        {
            Console.Clear();

            double[] times = new double[100];
            const int maxValue = 100000;
            int iterations = 100;
            int[] arr = new int[0];// tworzymy nową pustą tablicę
            Console.WriteLine("Czekaj...");

            // Powtarzanie operacji
            for (int i = 0; i < iterations; i++)
            {
                arr = new int[count];
                // Generowanie losowych liczb i dodawanie ich na końcu tablicy
                if (VariablesManager.IsManual)
                {
                    sw.Restart();
                    for (int j = 0; j < count; j++)
                    {

                        // Zwiększanie rozmiaru tablicy o 1
                        Array.Resize(ref arr, arr.Length + 1);

                        // Dodawanie  liczby na końcu
                        arr[arr.Length - 1] = VariablesManager.Array[j];

                    }
                    sw.Stop();
                }
                else
                {
                    arr = new int[count];
                    for (int j = 0; j < count; j++)
                    {
                        arr[j] = rnd.Next(count);
                    }
                    sw.Restart();

                    for (int j = 0; j < count; j++)
                    {
                        // Zwiększanie rozmiaru tablicy o 1
                        Array.Resize(ref arr, arr.Length + 1);

                        // Dodawanie losowej liczby na końcu
                        arr[arr.Length - 1] = rnd.Next(maxValue);
                    }
                    sw.Stop();
                }
                times[i] = sw.Elapsed.TotalMilliseconds;
                arr = new int[0];// tworzymy nową pustą tablicę przed każdą iteracją
            }
                Console.Clear();
                Console.WriteLine($"Czas najmniejszy: {times.Min()}, czas najwiekszy: {times.Max()}, czas średni: {times.Average()} ms");
            Console.WriteLine("Koniec zadania 3.");
            Menu();

        }

        /// <summary>
        /// dodawane lsoowcyh liczb w losowym miejscu tablicy
        /// </summary>
        public void AddToArraAtAtRandomIndex()
        {
            Console.Clear();
            int userIndex = 0;
            if (VariablesManager.IsManual)
            {
                Console.WriteLine("Podaj inseks w tablicy, na jakim ma zostać dodana liczba");
                Int32.TryParse(Console.ReadLine(), out userIndex);
                if (userIndex > count )
                {
                    Console.WriteLine($"Indeks jest większy niż wielkość tablicy ({count}), podaj mniejszy");
                    Int32.TryParse(Console.ReadLine(), out userIndex);
                }
            }
            double[] times = new double[100];
            const int maxValue = 100000;
            int iterations = 100;
            int[] arr = new int[0];// tworzymy nową pustą tablicę
            Console.WriteLine("Czekaj...");
            // Powtarzanie operacji
            for (int i = 0; i < iterations; i++)
            {
                
                // Generowanie losowych liczb i dodawanie ich na końcu tablicy
                if (VariablesManager.IsManual)
                {
                   arr= new int[count];
                    for (int j = 0; j < count; j++)
                    {
                        // Dodawanie  liczby na końcu
                        arr[j] = VariablesManager.Array[j];

                    } 

                    sw.Restart();
                    Array.Resize(ref arr, arr.Length + 1);
                    for (int k = arr.Length - 1; k > userIndex; k--)
                    {
                        arr[k] = arr[k - 1];
                    }
                    // Umieszczanie wylosowanej liczby w tablicy w losowym miejscu
                    int number = rnd.Next(maxValue);
                    arr[userIndex] = number;
                    sw.Stop();                  
                    Console.WriteLine($"wysolowana liczba to {number} i została wstawiona na indeks {userIndex}");

                }
                else
                {
                    arr = new int[count];
                    for (int j = 0; j < count; j++)
                    {
                        arr[j] = rnd.Next(count);
                    } 
                    sw.Restart();
                    for (int j = 0; j < count; j++)
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
                }
                
                times[i] = sw.Elapsed.TotalMilliseconds;
                Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalMilliseconds} ms");
                arr = new int[0];// tworzymy nową pustą tablicę przed każdą iteracją
            }
            //Console.Clear();
            Console.WriteLine($"Czas najmniejszy: {times.Min()} ms, czas najwiekszy: {times.Max()} ms, czas średni: {times.Average()} ms"); 
            Console.WriteLine("Koniec zadania 4.");
            Menu();

        }
        public void RemoveNumberFromFirtsIndexOfArray()
        {
            Console.Clear();

            double[] times = new double[100];
            const int maxValue = 1000;
            int iterations = 100;
            int[] arr = new int[0];// tworzymy nową pustą tablicę
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine("Czekaj...");
            //100 powtórzeń dla całego algorytmu
            for (int i = 0; i < iterations; i++)
            {
                if (VariablesManager.IsManual)
                {
                    arr = new int[count];
                    for (int j = 0; j < count; j++)
                    {
                        arr[j] = VariablesManager.Array[j];
                    }
                    sw.Restart();
                    for (int j = 0; j < arr.Length - 1; j++)
                    {
                        arr[j] = arr[j + 1];
                    }
                    Array.Resize(ref arr, arr.Length - 1);
                    sw.Stop();

                }
                else {
                    // Usuń pierwszą liczbę z początku tablicy a następnie zmniejsz rozmiar tablicy o 1
                   
                        arr = new int[count];
                        for (int j = 0; j < count; j++)
                        {
                            arr[j] = rnd.Next(maxValue);
                        }
                        sw.Restart();

                        for (int k = 0; k < arr.Length - 1; k++)
                        {
                            arr[k] = arr[k + 1];
                        }
                        Array.Resize(ref arr, arr.Length - 1);

                        sw.Stop();
                                        
                }
                times[i] = sw.Elapsed.TotalMilliseconds;

                Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalMilliseconds} sec");
                arr = new int[0];// tworzymy nową pustą tablicę przed każdą iteracją
            }
            //Console.Clear();
            Console.WriteLine($"Czas najmniejszy: {times.Min()} ms, czas najwiekszy: {times.Max()} ms, czas średni: {times.Average()} ms"); 
            Console.WriteLine("Koniec zadania 5.");
            Menu();


        }

        public void RemoveNumberFromLastIndexOfArray()
        {
            Console.Clear();

            double[] times = new double[100];
            const int maxValue = 1000;
            int iterations = 100;
            int[] arr = new int[0];// tworzymy nową pustą tablicę
     
            Console.WriteLine("Czekaj...");
            //100 powtórzeń dla całego algorytmu
            for (int i = 0; i < iterations; i++)
            {
                if (VariablesManager.IsManual)
                {
                    arr = new int[count];
                    for (int j = 0; j < count; j++)
                    {
                        arr[j] = VariablesManager.Array[j];
                    }
                    //skraca tablice o jeden element (ostatni)
                    sw.Restart();
                    Array.Resize(ref arr, arr.Length -1);
                    sw.Stop();

                }
                else
                {
                    arr = new int[count];
                    for (int j = 0; j < count; j++)
                    {
                        arr[j] = rnd.Next(maxValue);
                    }
                 
                    // Usuń liczbę z końca tablicy a następnie zmniejsz rozmiar tablicy o 1
                    
                    sw.Restart();

                    Array.Resize(ref arr, arr.Length - 1);

                    sw.Stop();

                    
                    
                }

                times[i] = sw.Elapsed.TotalMilliseconds * 1000000;
                Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalMilliseconds * 1000000} ns");
                arr = new int[0];// tworzymy nową pustą tablicę przed każdą iteracją
            }
            Console.WriteLine($"Czas najmniejszy: {times.Min()} ns, czas najwiekszy: {times.Max()} ns, czas średni: {times.Average()} ns");
            Console.WriteLine("Koniec zadania 6.");
            Menu();


        }

        public void RemoveNumberFromRadnomIndexOfArray()
        {
            Console.Clear();

            double[] times = new double[100];
            const int maxValue = 1000;
            int iterations = 100;
            int[] arr = new int[0];// tworzymy nową pustą tablicę
            int userIndex = 0;
            if (VariablesManager.IsManual)
            {
                Console.WriteLine("Podaj liczbę jaką chcesz znaleść");
                Int32.TryParse(Console.ReadLine(), out userIndex);
                if (userIndex > count)
                {
                    Console.WriteLine($"Indeks jest większy niż wielkość tablicy ({count}), podaj mniejszy");
                    Int32.TryParse(Console.ReadLine(), out userIndex);
                }
            }

            Console.WriteLine("Czekaj...");
            //100 powtórzeń dla całego algorytmu
            for (int i = 0; i < iterations; i++)
            {
                if (VariablesManager.IsManual)
                {
                    arr = new int[count];
                    for (int j = 0; j < count; j++)
                    {
                        arr[j] = VariablesManager.Array[j];
                    }
                    //skraca tablice o jeden element (ostatni)
                    int number = arr[userIndex];
                    sw.Restart();
                    // Przesuwanie elementów tablicy od wybranego indeksu o 1 w lewo (idąc w prawo)
                    for (int k = userIndex; k < arr.Length-1 ; k++)
                    {
                        arr[k] = arr[k + 1];
                    }
                    Array.Resize(ref arr, arr.Length - 1);
                    sw.Stop();
                    //Console.WriteLine($"liczba usunięta z indeksu {userIndex} to  {number} ");

                }
                else
                {
                    arr = new int[count];
                    for (int j = 0; j < count; j++)
                    {
                        arr[j] = rnd.Next(0, arr.Length - 1);
                    }
                    // Usuń liczbę z końca tablicy a następnie zmniejsz rozmiar tablicy o 1
                   
                    int indexToRemove = rnd.Next(maxValue); // losowy indeks do usunięcia
                    sw.Restart();
                    for (int k = indexToRemove; k < arr.Length - 1; k++)
                    {
                        arr[k] = arr[k + 1];
                    }

                    Array.Resize(ref arr, arr.Length - 1);

                    sw.Stop();

                    
                   
                    Array.Resize(ref arr, arr.Length - 1); // zmniejszenie rozmiaru tablicy
                }
                times[i] = sw.Elapsed.TotalMilliseconds * 1000000;
                Console.WriteLine($"Iteracja {i + 1}: {sw.Elapsed.TotalMilliseconds * 1000000} ns");
                arr = new int[0];// tworzymy nową pustą tablicę przed każdą iteracją
            }
            Console.WriteLine($"Czas najmniejszy: {times.Min()} ns, czas najwiekszy: {times.Max()} ns, czas średni: {times.Average()} ns");
            Console.WriteLine("Koniec zadania 7.");
            Menu();


        }
    }
}

