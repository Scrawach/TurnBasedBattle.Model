using System.Collections.Generic;
using TurnBasedBattle.Model.Core.Entities.Abstract;

namespace TurnBasedBattle.Model.Core.Services.Characters
{
    public class CharacterRegistry : ICharacterProvider, ICharacterRegistry
    {
        private readonly List<IEntity> _entities;

        public CharacterRegistry() =>
            _entities = new List<IEntity>();

        public IEnumerable<IEntity> All() =>
            _entities;

        public ICharacterRegistry Add(IEntity character)
        {
            _entities.Add(character);
            return this;
        }

        public ICharacterRegistry Remove(IEntity character)
        {
            _entities.Remove(character);
            return this;
        }

        public void Dispose() =>
            _entities.Clear();
    }
}