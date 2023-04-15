using StudyOfTheEffectivenessOperations.Helpers;
using StudyOfTheEffectivenessOperations.Operation.ArrayOperation;
using StudyOfTheEffectivenessOperations.Operation.BidirectionaListOperation;
using StudyOfTheEffectivenessOperations.Operation.BinaryTreeOperation;
using StudyOfTheEffectivenessOperations.Operation.BlackRedTreeOperation;
using StudyOfTheEffectivenessOperations.Operation.LinkedListOperation;
using System;

namespace StudyOfTheEffectivenessOperations
{
    internal static class MainMenu
    {
        public static void ShowMenu()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\r\nWybierz strukturę, na której chcesz przeprowadzić eksperymenty:\r\n");
            string menu = "[1] Tablica\r\n";
                    menu += "[2] Lista dwukierunkowa\r\n";
                    menu += "[3] Kopiec binanry\r\n";
                    menu += "[4] Drzewo czerwono-czarne\r\n";
                    menu += "--------------------------\r\n";
                    menu += "[5] Zmiana zestawu danych\r\n";
                    menu += "[6] Wyjście z programu\r\n";
            Console.WriteLine(menu);
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
                    LinkedListOperation linked = new LinkedListOperation();
                    break;
                case "3":
                    ColorizeString("Wybrany został Kopiec binarny\r\n");
                    BinaryHeapWithMaxOperation tree = new BinaryHeapWithMaxOperation();
                    break;
                case "4":
                    ColorizeString("Wybrane zostało Drzewo czerwono-czarne\r\n");
                    BlackRedTreeOperation blackRedTreeOp = new BlackRedTreeOperation();
                    break;
                case "5":
                    ColorizeString("Wybrane zostało wygenerowanie nowego zestawu danych\r\n");
                    FileOperation.Create();
                    ShowMenu();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default: ShowMenu();
                    break;
            }
        }
        public static void ColorizeString(string Text, ConsoleColor setColor = ConsoleColor.Green)
        {
            Console.ForegroundColor = setColor;
            Console.Write(Text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
