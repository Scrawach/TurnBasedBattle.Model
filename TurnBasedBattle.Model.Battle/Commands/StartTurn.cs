using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Commands.Abstract.Results;
using TurnBasedBattle.Model.Core.Entities.Abstract;

namespace TurnBasedBattle.Model.Battle.Commands
{
    public sealed class StartTurn : ICommand
    {
        public readonly IEntity Target;

        public StartTurn(IEntity target) =>
            Target = target;
        
        public ICommandResult Execute(ICoreMechanics core) =>
            new Success();

        public override string ToString() =>
            $"{Target} start turn";
    }
}