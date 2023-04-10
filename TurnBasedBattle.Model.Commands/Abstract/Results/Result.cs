using System.Collections.Generic;

namespace TurnBasedBattle.Model.Commands.Abstract.Results
{
    public class Result : ICommandResult
    {
        private readonly List<ICommand> _children;
        
        public Result(params ICommand[] children) =>
            _children = new List<ICommand>(children);

        public IEnumerable<ICommand> Children => _children;

        public void AddChildren(ICommand child) =>
            _children.Add(child);
    }
}