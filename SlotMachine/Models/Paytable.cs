namespace SlotMachine.Models
{
    public class Paytable
    {
        public Dictionary<string, List<int>> Payouts { get; private set; }

        public Paytable(Dictionary<string, List<int>> payouts)
        {
            Payouts = payouts;
        }

        public int GetPayout(string symbol, int matchCount)
        {
            if (Payouts.ContainsKey(symbol) && matchCount >= 3 && matchCount <= 5)
            {
                return Payouts[symbol][matchCount - 3];
            }
            return 0;
        }
    }
}
