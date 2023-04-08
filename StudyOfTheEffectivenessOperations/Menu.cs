using StudyOfTheEffectivenessOperations.Operation.BinaryTreeOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOfTheEffectivenessOperations
{
    internal static class Menu
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
                    Console.Write("Wybrana została Tablica\r\n");
                    //ArrayOperation arrayOp = new ArrayOperation();
                    break;
                case "2":
                    Console.Write("Wybrana została Lista dwukierunkowa\r\n");
                    //BidirectionaListOperation listOp = new BidirectionaListOperation();
                    break;
                case "3":
                    Console.Write("Wybrany został Kopiec binarny\r\n");
                    BinaryTreeOperation tree = new BinaryTreeOperation();
                    break;
                case "4":
                    Console.Write("Wybrane zostało Drzewo czerwono-czarne\r\n");
                    //BlackRedTreeOperation blackRedTreeOp = new BlackRedTreeOperation();
                    break;
                default: ShowMenu();
                    break;
            }
        }
    }
}
