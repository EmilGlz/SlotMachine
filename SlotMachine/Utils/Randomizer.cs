namespace SlotMachine.Utils
{
    public static class Randomizer
    {
        private static readonly Random _random = new Random();

        public static int GetRandomStopPosition(int bandLength)
        {
            return _random.Next(0, bandLength);
        }
    }
}
