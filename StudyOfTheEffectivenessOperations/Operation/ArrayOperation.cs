using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOfTheEffectivenessOperations.Operation.ArrayOperation
{
    public class ArrayOperation
    {
        private int[] array_operation_init;
   
        public ArrayOperation(int[] arr) {
            array_operation_init=arr;

            //pętla 100 dodanych elementów
            Stopwatch swAdd = Stopwatch.StartNew();
            Random random = new Random();
            for (int i = 0; i <= 100; i++)
            {
                
                AddToArray();
                
            }
        }
        public void Menu()
        {
            //string menu = "Wybierz numer wskazujący która akcja ma zostać wykonana wykonać na tablicy.";
            //menu += Environment.NewLine + "Każda wybrana akcja zostanie powtórzona w pętli 100 razy a czas wykonania uśredniony";
            //menu += Environment.NewLine + 
            //Console.WriteLine("Wybierz numer wskazujący która akcja ma zostać wykonana wykonać na tablicy.\r\nKażda wybrana kacja zostanie powórzona w pętli 100 razy a cza");
            //Console.WriteLine("[1] Dodwanie 100 losywhc")
        }
        public void AddToArray() {

            //Array.Resize(ref array_operation_init, array_operation_init.Length + 1);
            //array_operation_init[array_operation_init.Length - 1] = random.Next();
            //swAdd.Stop();
            //Console.WriteLine("Czas dodawania: {0} ms", swAdd.ElapsedMilliseconds);
        }
    }
}
