using System.Collections.Generic;
using TurnBasedBattle.Model.Commands.Implementations;

namespace TurnBasedBattle.Model.Commands.Abstract
{
    public interface ICommand
    {
        CommandStatus Status { get; }
        IEnumerable<ICommand> Children { get; }
        void Execute(ICoreMechanics core);
    }
}