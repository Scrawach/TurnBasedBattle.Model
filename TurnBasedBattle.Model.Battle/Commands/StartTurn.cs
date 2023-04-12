using CodeBase.Model.TurnBasedBattle.Model.TurnBasedBattle.Model.Commands.Extensions;
using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Commands.Abstract.Results;
using TurnBasedBattle.Model.Commands.Implementations;
using TurnBasedBattle.Model.Core.Entities.Abstract;

namespace TurnBasedBattle.Model.Battle.Commands
{
    public sealed class StartTurn : ICommand
    {
        public readonly IEntity Target;
        private readonly ICommand _action;

        public StartTurn(IEntity target, ICommand action)
        {
            Target = target;
            _action = action;
        }

        public ICommandResult Execute(ICoreMechanics core) =>
            new Result()
                .With(_action)
                .With(new InitiativeBurnFull(Target));

        public override string ToString() =>
            $"{Target} start turn";
    }
}