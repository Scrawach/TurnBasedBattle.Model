using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Commands.Abstract.Results;
using TurnBasedBattle.Model.Core.Entities.Abstract;

namespace TurnBasedBattle.Model.Battle.Commands
{
    public sealed class StartBattle : ICommand
    {
        public readonly IEntity Player;
        public readonly IEntity Enemy;

        public StartBattle(IEntity player, IEntity enemy)
        {
            Player = player;
            Enemy = enemy;
        }
        
        public ICommandResult Execute(ICoreMechanics core) =>
            new Success();

        public override string ToString() =>
            $"Start battle";
    }
}