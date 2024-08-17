using SlotMachine.Contracts;
using SlotMachine.Models;
namespace SlotMachine.Services
{
    public class SlotMachineService
    {
        private readonly IReelConfig _config;

        public SlotMachineService(IReelConfig reelConfig)
        {
            _config = reelConfig;
        }

        public SpinResult SpinReels()
        {
            var stopPositions = _config.GetStopPositions();
            var screen = GetScreen(stopPositions);
            return new SpinResult(stopPositions, screen);
        }

        private string[,] GetScreen(int[] stopPositions)
        {
            var screen = new string[3, 5];
            for (int i = 0; i < _config.ReelBands.Count; i++)
            {
                var visibleSymbols = _config.ReelBands[i].GetVisibleSymbols(stopPositions[i]);
                for (int j = 0; j < 3; j++)
                    screen[j, i] = visibleSymbols[j];
            }
            return screen;
        }

        public void DisplayScreen(SpinResult spinResult)
        {
            Console.WriteLine($"Stop Positions: {string.Join(", ", spinResult.StopPositions)}");
            Console.WriteLine("Screen:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                    Console.Write($"{spinResult.Screen[i, j]} ");
                Console.WriteLine();
            }
        }
    }
}
