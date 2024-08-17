using SlotMachine.Contracts;
using SlotMachine.Models;

namespace Testing.Mock
{
    public class MockPaytableConfig : IPayTableConfig
    {
        public Paytable Paytable { get; set; }

        public MockPaytableConfig()
        {
            Paytable = new Paytable(new Dictionary<string, List<int>>
            {
                // 3,4,5 of a kind
                { "sym1", new List<int> { 1, 2, 3 } },
                { "sym2", new List<int> { 1, 2, 3 } },
                { "sym3", new List<int> { 1, 2, 5 } },
                { "sym4", new List<int> { 2, 5, 10 } },
                { "sym5", new List<int> { 5, 10, 15 } },
                { "sym6", new List<int> { 5, 10, 15 } },
                { "sym7", new List<int> { 5, 10, 20 } },
                { "sym8", new List<int> { 10, 20, 50 } }
            });
        }
    }
}
