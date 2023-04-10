using StudyOfTheEffectivenessOperations.Operation;
using StudyOfTheEffectivenessOperations.Operation.ArrayOperation;
using StudyOfTheEffectivenessOperations.Operation.BinaryTreeOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOfTheEffectivenessOperations
{
    internal static class MainMenu
    {
        public static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\r\nWybierz strukturę, na której chcesz przeprowadzić eksperymenty:");
            string menu = "[1] Tablica\r\n";
            menu += "[2] Lista dwukierunkowa\r\n";
            menu += "[3] Kopiec binanry\r\n";
            menu += "[4] Drzewo czerwono-czarne\r\n";
            Console.Write(menu);
            string key = Console.ReadLine();

            switch (key)
            {
                case "1":
                    ColorizeString("Wybrana została Tablica\r\n");
                    ArrayOperation arrayOp = new ArrayOperation();
                    break;
                case "2":
                    ColorizeString("Wybrana została Lista dwukierunkowa\r\n");
                    //BidirectionaListOperation listOp = new BidirectionaListOperation();
                    break;
                case "3":
                    ColorizeString("Wybrany został Kopiec binarny\r\n");
                    BinaryHeapWithMaxOperation tree = new BinaryHeapWithMaxOperation();
                    break;
                case "4":
                    ColorizeString("Wybrane zostało Drzewo czerwono-czarne\r\n");
                    //BlackRedTreeOperation blackRedTreeOp = new BlackRedTreeOperation();
                    break;
                default: ShowMenu();
                    break;
            }
        }
        public static void ColorizeString(string Text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
