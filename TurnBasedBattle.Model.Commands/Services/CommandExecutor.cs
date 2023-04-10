using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Commands.Services.Abstract;
using TurnBasedBattle.Model.EventBus.Abstract;

namespace TurnBasedBattle.Model.Commands.Services
{
    public sealed class CommandExecutor : ICommandExecutor
    {
        private readonly IEventBus<ICommand> _emitter;
        private readonly ICoreMechanics _core;

        public CommandExecutor(IEventBus<ICommand> emitter, ICoreMechanics core)
        {
            _emitter = emitter;
            _core = core;
        }

        public void Execute(ICommand command)
        {
            var result = command.Execute(_core);
            _emitter.Start(command);
            foreach (var child in result.Children) 
                Execute(child);
            _emitter.Done(command);
        }
    }
}