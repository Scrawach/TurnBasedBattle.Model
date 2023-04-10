using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Commands.Abstract.Results;
using TurnBasedBattle.Model.Core.Entities.Abstract;

namespace TurnBasedBattle.Model.Battle.Commands
{
    public sealed class Spawn : ICommand
    {
        public IEntity Spawned { get; }
        
        public Spawn(IEntity entity) =>
            Spawned = entity;

        public ICommandResult Execute(ICoreMechanics core) =>
            new Success();

        public override string ToString() =>
            $"Spawn entity";
    }
}