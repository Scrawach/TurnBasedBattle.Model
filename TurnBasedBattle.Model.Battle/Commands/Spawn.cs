using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Commands.Abstract.Results;
using TurnBasedBattle.Model.Core.Entities.Abstract;
using TurnBasedBattle.Model.Core.Factory.Abstract;

namespace TurnBasedBattle.Model.Battle.Commands
{
    public sealed class Spawn : ICommand
    {
        private readonly IFactory _factory;

        public IEntity Spawned { get; private set; }
        
        public Spawn(IFactory factory) =>
            _factory = factory;

        public ICommandResult Execute(ICoreMechanics core)
        {
            var entity = _factory.Create();
            Spawned = entity;
            return new Success();
        }

        public override string ToString() =>
            $"Spawn entity";
    }
}