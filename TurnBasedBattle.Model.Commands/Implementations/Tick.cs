using TurnBasedBattle.Model.Commands.Abstract;

namespace TurnBasedBattle.Model.Commands.Implementations
{
    public sealed class Tick : BaseCommand
    {
        public readonly int InitiativeIncrease;

        public Tick(int initiativeIncrease) =>
            InitiativeIncrease = initiativeIncrease;
        
        protected override CommandStatus OnExecute(ICoreMechanics core)
        {
            foreach (var character in core.Characters.All()) 
                Children.Add(new IncreaseInitiative(character, InitiativeIncrease));
            
            return Success();
        }

        public override string ToString() =>
            $"{nameof(Tick)}";
    }
}