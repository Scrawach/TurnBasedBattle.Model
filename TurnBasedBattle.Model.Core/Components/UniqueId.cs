using TurnBasedBattle.Model.Core.Entities.Abstract;

namespace TurnBasedBattle.Model.Core.Components
{
    public sealed class UniqueId : IComponent
    {
        public UniqueId(string key, int number)
        {
            Key = key;
            Number = number;
        }

        public string Key { get; }
        
        public int Number { get; }

        public override string ToString() => 
            $"{Key}-{Number}";
    }
}