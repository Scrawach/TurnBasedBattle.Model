using System;
using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Commands.Abstract.Results;

namespace CodeBase.Model.TurnBasedBattle.Model.TurnBasedBattle.Model.Commands.Extensions
{
    public static class CommandResultExtensions
    {
        public static Result With(this Result result, ICommand child, bool when = true)
        {
            if (when)
                result.AddChildren(child);
            return result;
        }

        public static Result With(this Result result, ICommand child, Func<bool> when)
        {
            if (when())
                result.AddChildren(child);
            return result;
        }
    }
}