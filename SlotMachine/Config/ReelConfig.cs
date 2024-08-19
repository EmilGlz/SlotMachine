using SlotMachine.Contracts;
using SlotMachine.Models;
namespace SlotMachine.Config
{
    public class ReelConfig : IReelConfig
    {
        public ReelConfig()
        {
            ReelBands = new List<Reel>
            {
                new(1, new List<string> { "sym2", "sym7", "sym7", "sym1", "sym1", "sym5", "sym1", "sym4", "sym5", "sym3", "sym2", "sym3", "sym8", "sym4", "sym5", "sym2", "sym8", "sym5", "sym7", "sym2" }),
                new(2, new List<string> { "sym1", "sym6", "sym7", "sym6", "sym5", "sym5", "sym8", "sym5", "sym5", "sym4", "sym7", "sym2", "sym5", "sym7", "sym1", "sym5", "sym6", "sym8", "sym7", "sym6", "sym3", "sym3", "sym6", "sym7", "sym3" }),
                new(3, new List<string> { "sym5", "sym2", "sym7", "sym8", "sym3", "sym2", "sym6", "sym2", "sym2", "sym5", "sym3", "sym5", "sym1", "sym6", "sym3", "sym2", "sym4", "sym1", "sym6", "sym8", "sym6", "sym3", "sym4", "sym4", "sym8", "sym1", "sym7", "sym6", "sym1", "sym6" }),
                new(4, new List<string> { "sym2", "sym6", "sym3", "sym6", "sym8", "sym8", "sym3", "sym6", "sym8", "sym1", "sym5", "sym1", "sym6", "sym3", "sym6", "sym7", "sym2", "sym5", "sym3", "sym6", "sym8", "sym4", "sym1", "sym5", "sym7" }),
                new(5, new List<string> { "sym7", "sym8", "sym2", "sym3", "sym4", "sym1", "sym3", "sym2", "sym2", "sym4", "sym4", "sym2", "sym6", "sym4", "sym1", "sym6", "sym1", "sym6", "sym4", "sym8" })
            };
        }

        public List<Reel> ReelBands { get; set; }

        public int[] GetStopPositions()
        {
            var stopPositions = new int[ReelBands.Count];
            for (int i = 0; i < ReelBands.Count; i++)
            {
                var random = new Random();
                stopPositions[i] = random.Next(0, ReelBands[i].Band.Count);
            }
            return stopPositions;
        }
    }
}
