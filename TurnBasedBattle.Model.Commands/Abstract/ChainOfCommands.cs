namespace TurnBasedBattle.Model.Commands.Abstract
{
    public class ChainOfCommands : BaseCommand
    {
        private readonly ICommand[] _commands;

        public ChainOfCommands(params ICommand[] commands) =>
            _commands = commands;
        
        protected override CommandStatus OnExecute()
        {
            foreach (var command in _commands) 
                Children.Add(command);
            return Success();
        }
    }
}