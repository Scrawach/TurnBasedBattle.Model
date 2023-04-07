
using System.Collections.Generic;
using TurnBasedBattle.Model.Commands.Implementations;

namespace TurnBasedBattle.Model.Commands.Abstract
{
    public abstract class BaseCommand : ICommand
    {
        public CommandStatus Status { get; private set; }

        protected List<ICommand> Children { get; } = new List<ICommand>();

        IEnumerable<ICommand> ICommand.Children => Children;
    
        void ICommand.Execute(ICoreMechanics core)
        {
            Children.Clear();
            Status = OnExecute(core);
        }

        protected abstract CommandStatus OnExecute(ICoreMechanics core);

        protected static CommandStatus Success() => CommandStatus.Success;
    
        protected static CommandStatus Fail() => CommandStatus.Failed;
    }
}