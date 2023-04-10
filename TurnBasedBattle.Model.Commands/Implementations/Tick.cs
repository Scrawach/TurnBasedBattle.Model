using System.Collections.Generic;
using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Commands.Abstract.Results;

namespace TurnBasedBattle.Model.Commands.Implementations
{
    public sealed class Tick : ICommand
    {
        public readonly int InitiativeIncrease;

        public Tick(int initiativeIncrease) =>
            InitiativeIncrease = initiativeIncrease;
        
        public ICommandResult Execute(ICoreMechanics core)
        {
            var commands = new List<ICommand>();
            
            foreach (var character in core.Characters.All()) 
                commands.Add(new IncreaseInitiative(character, InitiativeIncrease));
            
            return new Result(commands.ToArray());
        }

        public override string ToString() =>
            $"{nameof(Tick)}";
    }
}