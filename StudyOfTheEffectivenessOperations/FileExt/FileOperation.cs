using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StudyOfTheEffectivenessOperations.FileExt
{
    internal class FileOperation
    {
        private readonly string _filePath;
        private readonly int _elementLength;
        private readonly FileInfo _fileInfo;
        private int[] array;

        public int[] ArrayNumbers { get => array; set => array = value; }

        public FileOperation()
        {
             _filePath = String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"\\liczby.txt");
            _fileInfo = new FileInfo(_filePath);
            Create();
        }
        
        private void Create()
        {
            

            if (!_fileInfo.Exists)
            {
                AddToFile();
            }
            else if (_fileInfo.Length == 0)
            {
                File.Delete(_filePath);
                AddToFile();
            }
            else
            {
                Console.WriteLine("Utworzyć nowy zestaw danych? (T) utowrzyć/ (N) wczytać istniejący");
                Read(Console.ReadKey());
            }
            
        }
        private void AddToFile()
        {
            using (StreamWriter sw = _fileInfo.CreateText())
                {
                    //sw.WriteLine("100\r\n"/*+ Environment.NewLine*/);
                    string number = string.Empty;
                    Random rand = new Random();
                    int counter = 20000;
                    for (int i = 0; i < counter; i++)
                    {
                        int randInt = rand.Next(1000);
                        number += i == 99 ? randInt.ToString() : randInt.ToString() + ";";
                    }
                    sw.WriteLine(counter.ToString() + Environment.NewLine+ number);
                    Console.Write(Environment.NewLine+counter.ToString() + Environment.NewLine + number);
                    Console.ReadLine();
                }
        }
        private void Read(ConsoleKeyInfo consoleKeyInfo)
        {
            if(consoleKeyInfo.Key == ConsoleKey.T)
            {
                File.Delete(_filePath);
                AddToFile();
            }
            else if(consoleKeyInfo.Key == ConsoleKey.N)
            {
                var lines = File.ReadLines(_filePath);
                Console.WriteLine(Environment.NewLine);

                foreach (var line in lines)
                {
                    Console.WriteLine($"{line}");
                    if (line.Contains(";"))
                    {
                        ArrayNumbers = line.Split(';').Select(str => int.Parse(str.Trim())).ToArray();
                    }
                }

            }
            Console.ReadKey();
        }
    }
}
