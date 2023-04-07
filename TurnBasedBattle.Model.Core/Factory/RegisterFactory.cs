using TurnBasedBattle.Model.Core.Entities.Abstract;
using TurnBasedBattle.Model.Core.Factory.Abstract;
using TurnBasedBattle.Model.Core.Services.Characters;

namespace TurnBasedBattle.Model.Core.Factory
{
    public sealed class RegisterFactory : IFactory
    {
        private readonly IFactory _origin;
        private readonly ICharacterRegistry _registry;

        public RegisterFactory(IFactory origin, ICharacterRegistry registry)
        {
            _origin = origin;
            _registry = registry;
        }
        
        public IEntity Create()
        {
            var entity = _origin.Create();
            _registry.Add(entity);
            return entity;
        }
    }
}