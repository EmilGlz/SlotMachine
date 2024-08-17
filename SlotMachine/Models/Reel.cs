namespace SlotMachine.Models
{
    public class Reel
    {
        public List<string> Band { get; set; }
        public int ReelIndex { get; private set; }
        public Reel(int reelIndex, List<string> band)
        {
            ReelIndex = reelIndex;
            Band = band;
        }

        public string[] GetVisibleSymbols(int stopPosition)
        {
            string[] visibleSymbols = new string[3];
            for (int i = 0; i < 3; i++)
            {
                int index = (stopPosition + i) % Band.Count;
                visibleSymbols[i] = Band[index];
            }
            return visibleSymbols;
        }
    }
}
