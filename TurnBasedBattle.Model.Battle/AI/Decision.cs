using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Core.Entities.Abstract;

namespace TurnBasedBattle.Model.Battle.AI
{
    public sealed class Decision
    {
        public readonly IEntity Actor;
        public readonly ICommand Action;

        public Decision(IEntity actor, ICommand action)
        {
            Actor = actor;
            Action = action;
        }
    }
}