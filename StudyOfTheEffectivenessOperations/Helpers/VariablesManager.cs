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
        private static int numberCount;
        private static int numberCountToRemove = 100;
        private static int[] array;

        public static int NumberCount { get => numberCount; set => numberCount = value; }
        public static int NumberCountToRemove { get => numberCountToRemove; set => numberCountToRemove = value; }
        public static int[] Array { get => array; set => array = value; }
        public static bool IsManual { get => isManual; set => isManual = value; }
        public static int DefaultQuantityBeforeAddOperation { get => defaultQuantityBeforeAddOperation; set => defaultQuantityBeforeAddOperation = value; }
    }
}
