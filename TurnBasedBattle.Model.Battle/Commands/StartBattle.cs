using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Commands.Abstract.Results;

namespace TurnBasedBattle.Model.Battle.Commands
{
    public sealed class StartBattle : ICommand
    {
        public ICommandResult Execute(ICoreMechanics core) =>
            new Success();

        public override string ToString() =>
            $"Start battle";
    }
}