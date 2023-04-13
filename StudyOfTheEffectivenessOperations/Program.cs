using StudyOfTheEffectivenessOperations.Helpers;
using System;

namespace StudyOfTheEffectivenessOperations
{
    public class Program
    {
         private int numberCount;
         private int numberCountToRemove;

         public int NumberCount { get => numberCount; set => numberCount = value; }
         public int NumberCountToRemove { get => numberCountToRemove; set => numberCountToRemove = value; }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ditrich Marcin i Proniewicz Andrzej\r\n");
            Console.WriteLine("Temat zadania: Badanie efektywności operacji na danych w podstawowych strukturach danych\r\n");
            Console.ForegroundColor = ConsoleColor.White;
            FileOperation.Create();
            MainMenu.ShowMenu();
          
        }
        
    }
}
