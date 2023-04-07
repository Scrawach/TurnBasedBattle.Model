using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Core.Entities.Abstract;

namespace TurnBasedBattle.Model.Battle.Commands
{
    public sealed class StartTurn : BaseCommand
    {
        public readonly IEntity Target;

        public StartTurn(IEntity target) =>
            Target = target;
        
        protected override CommandStatus OnExecute(ICoreMechanics core) =>
            Success();

        public override string ToString() =>
            $"{Target} start turn";
    }
}