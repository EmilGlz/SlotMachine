using SlotMachine.Models;

namespace SlotMachine.Contracts
{
    public interface IPayTableConfig
    {
        public Paytable Paytable { get; protected set; }
    }
}
