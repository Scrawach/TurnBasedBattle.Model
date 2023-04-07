using TurnBasedBattle.Model.Core.Entities.Abstract;

namespace TurnBasedBattle.Model.Core.Components
{
    public class Initiative : IComponent
    {
        public Initiative(int total) : this(total, total) { }
        
        public Initiative(int value, int total)
        {
            Value = value;
            Total = total;
        }
        
        public int Value { get; set; }
        
        public int Total { get; set; }

        public bool IsFull() =>
            Value == Total;
    }
}