using System;
using System.Collections.Generic;

namespace TurnBasedBattle.Model.Commands.Abstract.Results
{
    public class Fail : ICommandResult
    {
        public IEnumerable<ICommand> Children { get; } = Array.Empty<ICommand>();
    }
}