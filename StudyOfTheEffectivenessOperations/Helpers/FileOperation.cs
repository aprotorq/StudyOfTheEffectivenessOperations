using System;
using System.IO;
using System.Linq;

namespace StudyOfTheEffectivenessOperations.Helpers
{
    internal static class FileOperation
    {
        private static string _filePath;
        private static FileInfo _fileInfo;
        private static bool _manual;


        /// <summary>
        /// Tworzenie nowego pliku
        /// </summary>
        public static void Create()
        {
            string fileName = string.Concat("\\liczby.txt");
            //pobranie domyslnej ściezki do ppliku z danymi z pulpicie
            _filePath = String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
            //pobranie informacji o pliku
            _fileInfo = new FileInfo(_filePath);
            //sprawdzanie czy dany plik istnieje i ruchamianie operacji na nim
            Console.WriteLine($"Każda kolekcja przyjmuje zestaw początkowych danych wielkości {VariablesManager.QuantityToAutoFill} a dane z pliku (jesli będzie to test manualny) będą dodawane do danej kolekcji w trakcie eksperymentów.\r\n");
            Console.WriteLine("Czy chcesz zmienić początkowy zestaw danych? (T) tak, każda inna litera oznacza -NIE\r\n");
            if (Console.ReadKey().Key == ConsoleKey.T)
            {
                int count;
                Console.WriteLine("\r\nPodaj liczę początkowych danych");

                string consoleInput = Console.ReadLine();
                bool success = Int32.TryParse(consoleInput, out count);
                if (success)
                {
                    VariablesManager.QuantityToAutoFill = count;
                }
            }
            Console.WriteLine("\r\nUtworzyć nowy zestaw danych do manualnego testowania? (T) utworzyć/ (N) wczytać istniejący z pliku ");
            string key = Console.ReadLine().ToUpper();
            Read(key);
            
            
        }
        /// <summary>
        /// Dodawanie elementów do pliku 
        /// </summary>
        /// <param name="num">parametr domyślnie ustawiony jeżeli nie dostanie innego z zewnątrz</param>
        private static void AddToFile(int num = 20)
        {
            using (StreamWriter sw = _fileInfo.CreateText())
                {
                    //sw.WriteLine("100\r\n"/*+ Environment.NewLine*/);
                    string number = string.Empty;
                    Random rand = new Random(); 
                    int counter = num;
                    for (int i = 0; i < counter; i++)
                    {
                        int randInt = rand.Next(1000);
                        number += i == counter - 1? randInt.ToString() : randInt.ToString() + ";";
                    }
                    sw.WriteLine(counter.ToString() + Environment.NewLine+ number);
                    sw.Close();
                    Console.Write(Environment.NewLine+counter.ToString() + Environment.NewLine + number);
                    //Console.ReadLine();
                
            }
        }
        /// <summary>
        /// Metoda odpowiada za odczyt danych
        /// </summary>
        /// <param name="key">T/N - czy odczytać istnirejący plik, czy utworzyć nowy zestaw danych</param>
        private static void Read(string key)
        {   //tworzy nowy plik z podaną ilościa lemenetów
            if(key.Equals("T"))
            {
                VariablesManager.IsManual = true;
                Console.Write(Environment.NewLine+"Podaj sugerowaną ilość elementów"+ Environment.NewLine );
                int count;
                string consoleInput = Console.ReadLine();
                bool success = Int32.TryParse(consoleInput, out count);
                if (success)
                {
                    VariablesManager.RandomNumberCount= count;
                    File.Delete(_filePath);
                    AddToFile(count);
                    var lines = File.ReadLines(_filePath);

                    foreach (var line in lines)
                    {

                        if (line.Contains(";"))
                        {
                            VariablesManager.Array = line.Split(';').Select(str => Int32.Parse(str.Trim())).ToArray();
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Wprowadzona wartość nie była liczbą, czy chcesz spróbować ponownie? (T) Tak/ (N) Nie, wyjdź do menu głównego");
                    if (Console.ReadLine().ToUpper().Equals("T"))
                    {
                        Read("T");
                    }
                    else MainMenu.ShowMenu();
                }
            }
            else if(key.Equals("N"))
            {
                //wczytuje istniejący plik z elementami, jesli go nie ma to go utworzy a domyslnie będzie 20 liczb
                VariablesManager.IsManual = false;
                Console.WriteLine("Otwieram plik.");

                if (!_fileInfo.Exists)
                {
                    AddToFile();
                }
                else if (_fileInfo.Length == 0)
                {
                    File.Delete(_filePath);
                    AddToFile();
                }

                var lines = File.ReadLines(_filePath);

                foreach (var line in lines)
                {
                    int count;
                    bool success = Int32.TryParse(line, out count);
                    if (success)
                    {
                        VariablesManager.RandomNumberCount = count;
                    }
                   if (line.Contains(";"))
                    {
                        VariablesManager.Array = line.Split(';').Select(str => Int32.Parse(str.Trim())).ToArray();
                    }
                    
                }
                Console.WriteLine($"Dane zostaly wczytane z: {_filePath}");
                MainMenu.ShowMenu();
            }
            
        }
    }
}
