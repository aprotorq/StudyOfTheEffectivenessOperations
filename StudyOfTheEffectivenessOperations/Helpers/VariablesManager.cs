namespace StudyOfTheEffectivenessOperations.Helpers
{
    internal static class VariablesManager
    {
        private static int defaultQuantityBeforeAddOperation = 10000;
        private static int numberCountToRemove = 1;

        public static int RandomNumberCount { get; set; }
        public static int[] Array { get; set; }
        public static bool IsManual { get; set; }
        public static int NumberCountToRemove { get => numberCountToRemove; set => numberCountToRemove = value; }
        public static int QuantityToAutoFill { get => defaultQuantityBeforeAddOperation; set => defaultQuantityBeforeAddOperation = value; }
    }
}
