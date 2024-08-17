using SlotMachine.Config;
using SlotMachine.Services;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var reelConfig = new ReelConfig();
            var paytableConfig = new PaytableConfig();

            var slotMachineService = new SlotMachineService(reelConfig);
            var payoutService = new PayoutService(paytableConfig);

            var spinResult = slotMachineService.SpinReels();

            slotMachineService.DisplayScreen(spinResult);

            var totalWinnings = payoutService.CalculateWinnings(spinResult);
            Console.WriteLine($"Total wins: {totalWinnings}");
        }
    }
}
