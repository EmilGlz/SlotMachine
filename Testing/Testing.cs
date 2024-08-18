using SlotMachine.Services;
using Testing.Mock;

namespace Testing
{
    public class Testing
    {
        [Fact]
        public void CheckValues()
        {
            for (int i = 0; i < MockDatas.ReelBands.Count; i++)
            {
                var reelConfig = new MockReelConfig(MockDatas.ReelBands[i], MockDatas.StopPositions[i]);
                var paytableConfig = new MockPaytableConfig();

                var slotMachineService = new SlotMachineService(reelConfig);
                var payoutService = new PayoutService(paytableConfig);

                var spinResult = slotMachineService.SpinReels();

                payoutService.CalculateWinnings(spinResult);

                Assert.Equal(MockDatas.TotalWinningsResuls[i], spinResult.GetTotalWinnings());
            }
        }
    }
}