namespace SlotMachine.Models
{
    public class SpinResult
    {
        public int[] StopPositions { get; private set; }
        public string[,] Screen { get; private set; }
        public List<WinDetails> Wins { get; private set; }

        public SpinResult(int[] stopPositions, string[,] screen)
        {
            StopPositions = stopPositions;
            Screen = screen;
            Wins = new();
        }

        public void AddWin(WinDetails win)
        {
            Wins.Add(win);
        }

        public int GetTotalWinnings()
        {
            return Wins.Sum(win => win.Payout);
        }

        public void PrintWinnings()
        {
            Console.WriteLine($"Total wins: {GetTotalWinnings()}");
            foreach (var win in Wins)
                Console.WriteLine($"- Ways win {string.Join("-", win.WinningPositions)}, {win.Symbol} x{win.MatchCount}, {win.Payout}");
        }
    }

    public class WinDetails
    {
        public string Symbol { get; set; }
        public int MatchCount { get; set; }
        public int Payout { get; set; }
        public List<int> WinningPositions { get; set; }
    }
}
