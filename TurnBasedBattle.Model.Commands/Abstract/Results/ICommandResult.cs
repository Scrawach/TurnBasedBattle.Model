using System.Collections.Generic;

namespace TurnBasedBattle.Model.Commands.Abstract.Results
{
    public interface ICommandResult
    {
        IEnumerable<ICommand> Children { get; }
    }
}