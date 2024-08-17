namespace SlotMachine.Models
{
    public class Symbol
    {
        public string Id { get; private set; }
        public int PayValue { get; private set; }

        public Symbol(string id, int payValue)
        {
            Id = id;
            PayValue = payValue;
        }
    }
}
