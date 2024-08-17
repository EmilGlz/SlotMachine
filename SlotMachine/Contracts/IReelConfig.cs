using SlotMachine.Models;
namespace SlotMachine.Contracts
{
    public interface IReelConfig
    {
        public List<Reel> ReelBands { get; protected set; }

        public int[] GetStopPositions();
    }
}
