using SlotMachine.Services;
using Testing.Mock;

namespace Testing
{
    public class Testing
    {
        [Fact]
        public void CheckValues()
        {
            var reelConfig = new MockReelConfig();
            var paytableConfig = new MockPaytableConfig();

            var slotMachineService = new SlotMachineService(reelConfig);
            var payoutService = new PayoutService(paytableConfig);

            var spinResult = slotMachineService.SpinReels();

            var totalWinnings = payoutService.CalculateWinnings(spinResult);

            Assert.Equal(11, totalWinnings);
        }
    }
}