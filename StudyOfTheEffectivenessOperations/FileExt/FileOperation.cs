using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace StudyOfTheEffectivenessOperations.FileExt
{
    internal static class FileOperation
    {
        private static string _filePath;
        private static FileInfo _fileInfo;
        private static int _numberOfElements;
        private static int[] array;

        public static int[] ArrayNumbers { get => array; set => array = value; }

       
        /// <summary>
        /// Tworze nowego pliku
        /// </summary>
        public static void Create()
        {
            //pobranie domyslnej ściezki do ppliku z danymi z pulpicie
            _filePath = String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "\\liczby.txt");
            //pobranie informacji o pliku
            _fileInfo = new FileInfo(_filePath);
            //sprawdzanie czy dany plik istnieje i ruchamianie operacji na nim
            Console.WriteLine("Utworzyć nowy zestaw danych? (T) utowrzyć/ (N) wczytać istniejący");
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
                        number += i == counter-1? randInt.ToString() : randInt.ToString() + ";";
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
        {
            if(key.Equals("T"))
            {
                Console.Write(Environment.NewLine+"Podaj sugerowaną ilość"+ Environment.NewLine );
                int count;
                    string consoleInput = Console.ReadLine();
                bool success = Int32.TryParse(consoleInput, out count);
                if (success)
                {
                    File.Delete(_filePath);
                    AddToFile(count);
                    var lines = File.ReadLines(_filePath);
                    //Console.WriteLine(Environment.NewLine);

                    foreach (var line in lines)
                    {
                        //Console.WriteLine($"{line}");

                        if (line.Contains(";"))
                        {
                            ArrayNumbers = line.Split(';').Select(str => Int32.Parse(str.Trim())).ToArray();
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Wprowadzona wartość nie była liczbą, czy chcesz spróbować ponownie? (T) Tak/ (N) Nie, wyjdź");
                    if (Console.ReadLine().ToUpper().Equals("T"))
                    {
                        Read("T");
                    }
                    else Environment.Exit(0);
                }
            }
            else if(key.Equals("N"))
            {
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
                    
                   if (line.Contains(";"))
                    {
                        ArrayNumbers = line.Split(';').Select(str => Int32.Parse(str.Trim())).ToArray();
                    }
                    
                }
                Console.WriteLine($"Dane zostaly wczytane z: {_filePath}");
                MainMenu.ShowMenu();
            }
            
        }
    }
}
