using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOfTheEffectivenessOperations.Helpers
{
    internal static class VariablesManager
    {
        private static bool isManual;
        private static int defaultQuantityBeforeAddOperation = 10000;
        private static int randomNumberCount;
        private static int numberCountToRemove = 1;
        private static int[] array;

        public static int RandomNumberCount { get => randomNumberCount; set => randomNumberCount = value; }
        public static int NumberCountToRemove { get => numberCountToRemove; set => numberCountToRemove = value; }
        public static int[] Array { get => array; set => array = value; }
        public static bool IsManual { get => isManual; set => isManual = value; }
        public static int QuantityToAutoFill { get => defaultQuantityBeforeAddOperation; set => defaultQuantityBeforeAddOperation = value; }
    }
}
