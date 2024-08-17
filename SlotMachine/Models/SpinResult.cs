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
            Wins = new List<WinDetails>();
        }

        public void AddWin(WinDetails win)
        {
            Wins.Add(win);
        }

        public int CalculateTotalWinnings()
        {
            return Wins.Sum(win => win.Payout);
        }
    }

    public class WinDetails
    {
        public string Symbol { get; private set; }
        public int MatchCount { get; private set; }
        public int Payout { get; private set; }
        public List<int> WinningPositions { get; private set; }

        public WinDetails(string symbol, int matchCount, int payout, List<int> winningPositions)
        {
            Symbol = symbol;
            MatchCount = matchCount;
            Payout = payout;
            WinningPositions = winningPositions;
        }
    }
}
