using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Core.Entities.Abstract;
using TurnBasedBattle.Model.Core.Factory.Abstract;

namespace TurnBasedBattle.Model.Battle.Commands
{
    public sealed class Spawn : BaseCommand
    {
        private readonly IFactory _factory;

        public IEntity Spawned { get; private set; }
        
        public Spawn(IFactory factory) =>
            _factory = factory;

        protected override CommandStatus OnExecute(ICoreMechanics core)
        {
            var entity = _factory.Create();
            core.Characters.Add(entity);
            Spawned = entity;
            return Success();
        }
    }
}