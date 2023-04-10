using TurnBasedBattle.Model.Commands.Abstract.Results;

namespace TurnBasedBattle.Model.Commands.Abstract
{
    public sealed class ChainOfCommands : ICommand
    {
        private readonly ICommand[] _commands;

        public ChainOfCommands(params ICommand[] commands) =>
            _commands = commands;
        
        public ICommandResult Execute(ICoreMechanics core) =>
            new Result(_commands);
    }
}