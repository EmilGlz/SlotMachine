using SlotMachine.Contracts;
using SlotMachine.Models;
namespace Testing.Mock
{
    public class MockReelConfig : IReelConfig
    {
        private readonly int[] _stopPositions;

        public MockReelConfig(List<Reel> reelBands, int[] stopPositions)
        {
            ReelBands = reelBands; 
            _stopPositions = stopPositions;
        }

        public List<Reel> ReelBands { get; set; }

        public int[] GetStopPositions()
        {
            return _stopPositions;
        }
    }
}
