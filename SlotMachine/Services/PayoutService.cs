﻿using SlotMachine.Contracts;
using SlotMachine.Models;
using SlotMachine.Utils;
using System.Diagnostics;
using System.Linq;
using System.Net.Security;

namespace SlotMachine.Services
{
    public class PayoutService
    {
        private readonly IPayTableConfig _config;

        public PayoutService(IPayTableConfig paytableConfig)
        {
            _config = paytableConfig;
        }

        public void CalculateWinnings(SpinResult spinResult)
        {
            var screen = spinResult.Screen;
            var elementsOnScreen = GetUniqueElements(screen);
            foreach (var element in elementsOnScreen)
            {
                var positions = GetElementPositions(element, screen);
                if (positions.Count < 3)
                    continue;
                var (combinations, keys) = GetCombinations(positions);
                for (int j = 0; j < combinations.Count; j++)
                {
                    var rowIndexes = combinations[j];
                    var coloumnIndexes = keys[j];
                    List<int> winningPositions = new();
                    var newWinDetails = new WinDetails
                    {
                        Symbol = element,
                        MatchCount = coloumnIndexes.Count,
                        Payout = _config.Paytable.GetPayout(element, coloumnIndexes.Count)
                    };
                    for (int k = 0; k < coloumnIndexes.Count; k++)
                    {
                        var index = GetIndex(rowIndexes[k], coloumnIndexes[k]);
                        winningPositions.Add(index);
                    }
                    newWinDetails.WinningPositions = winningPositions;
                    spinResult.AddWin(newWinDetails);
                }
            }
        }

        private int GetIndex(int row, int coloumn)
            => 5 * row + coloumn;

        #region Methods for calculating combinations
        private static HashSet<string> GetUniqueElements(string[,] matrix)
        {
            var uniqueElements = new HashSet<string>();

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    uniqueElements.Add(matrix[row, col]);
                }
            }

            return uniqueElements;
        }
        private static Dictionary<int, List<int>> GetElementPositions(string element, string[,] matrix)
        {
            var positions = new Dictionary<int, List<int>>();

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int col = 0; col < cols; col++)
            {
                var rowList = new List<int>();
                for (int row = 0; row < rows; row++)
                {
                    if (matrix[row, col] == element)
                    {
                        rowList.Add(row);
                    }
                }

                if (rowList.Count > 0)
                {
                    positions[col] = rowList;
                }
                else if (positions.Count > 0 && rowList.Count == 0)
                    break;
            }

            return positions;
        }
        private static (List<List<int>> combinations, List<List<int>> keys) GetCombinations(Dictionary<int, List<int>> positions)
        {
            var combinations = new List<List<int>>();
            var keyTracking = new List<List<int>>();

            var lists = new List<List<int>>(positions.Values);
            var keyLists = new List<List<int>>();
            foreach (var key in positions.Keys)
            {
                keyLists.Add(new List<int> { key });
            }

            void GenerateCombinations(int depth, List<int> currentCombination, List<int> currentKeys)
            {
                // Base case: if we've considered all lists
                if (depth == lists.Count)
                {
                    combinations.Add(new List<int>(currentCombination));
                    keyTracking.Add(new List<int>(currentKeys));
                    return;
                }

                // Recursive case: iterate over each element in the current list
                foreach (var item in lists[depth])
                {
                    currentCombination.Add(item);
                    currentKeys.Add(keyLists[depth][0]); // Use the key corresponding to the current list
                    GenerateCombinations(depth + 1, currentCombination, currentKeys);
                    currentCombination.RemoveAt(currentCombination.Count - 1); // Backtrack
                    currentKeys.RemoveAt(currentKeys.Count - 1); // Backtrack
                }
            }

            GenerateCombinations(0, new List<int>(), new List<int>());

            return (combinations, keyTracking);
        }
        #endregion
    }
}
