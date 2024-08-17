using SlotMachine.Contracts;
using SlotMachine.Models;

namespace SlotMachine.Services
{
    public class PayoutService
    {
        private readonly IPayTableConfig _config;

        public PayoutService(IPayTableConfig paytableConfig)
        {
            _config = paytableConfig;
        }

        public int CalculateWinnings(SpinResult spinResult)
        {
            var totalWinnings = 0;
            Dictionary<int, List<string>> coloumnValues = new();
            var screen = spinResult.Screen;
            var rowCount = screen.GetLength(0);
            var coloumnCount = screen.GetLength(1);
            // This loop is only to fill the elements to the dictionary so that we can see more clearly later
            for (int i = 0; i < coloumnCount; i++)
            {
                var elementsInColoumn = new List<string>();
                for (int j = 0; j < rowCount; j++)
                {
                    var symbol = screen[j, i];
                    elementsInColoumn.Add(symbol);
                }
                coloumnValues.Add(i, elementsInColoumn);
            }

            foreach (var coloumnData in coloumnValues)
            {
                var elements = coloumnData.Value;
                var coloumnIndex = coloumnData.Key;
                if(coloumnValues.ContainsKey(coloumnIndex + 1)) // if we are not in the last coloumn
                {
                    // TODO check if there are more than one same element in one coloumn and the same element exists
                    // on the next element, add to the list, and remove duplicated item from coloumn
                }
            }


            foreach (var win in spinResult.Wins)
            {
                Console.WriteLine($"- Ways win {string.Join("-", win.WinningPositions)}, {win.Symbol} x{win.MatchCount}, {win.Payout}");
            }

            return totalWinnings;
        }

        static void FindWinningCombinations(string[,] screen, int row, int col, string symbol, HashSet<int> visited, List<int> winningPositions)
        {
            int index = row * screen.GetLength(1) + col;

            if (visited.Contains(index) || screen[row, col] != symbol)
                return;

            visited.Add(index);
            winningPositions.Add(index);

            if (col + 1 < screen.GetLength(1))
            {
                for (int nextRow = 0; nextRow < screen.GetLength(0); nextRow++)
                {
                    FindWinningCombinations(screen, nextRow, col + 1, symbol, visited, winningPositions);
                }
            }
        }
    }
}
