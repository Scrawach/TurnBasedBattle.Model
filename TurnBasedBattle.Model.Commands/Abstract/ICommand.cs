using TurnBasedBattle.Model.Commands.Abstract.Results;

namespace TurnBasedBattle.Model.Commands.Abstract
{
    public interface ICommand
    {
        ICommandResult Execute(ICoreMechanics core);
    }
}