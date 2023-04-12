using System.Collections.Generic;
using System.Linq;
using TurnBasedBattle.Model.Core.Components;
using TurnBasedBattle.Model.Core.Data;
using TurnBasedBattle.Model.Core.Entities.Abstract;
using TurnBasedBattle.Model.Core.Extensions;
using TurnBasedBattle.Model.Core.Services.Characters.Abstract;

namespace TurnBasedBattle.Model.Core.Services.Characters
{
    public sealed class CharacterRegistry : ICharacterRegistry
    {
        private readonly List<IEntity> _entities;

        public CharacterRegistry() =>
            _entities = new List<IEntity>();

        public IEnumerable<IEntity> All() =>
            _entities;

        public IEnumerable<IEntity> EnemiesOf(Team team) =>
            from entity in _entities 
            let target = entity.Get<TeamMarker>().Team 
            where team.IsEnemiesOf(target) select entity;

        public IEnumerable<IEntity> AlliesOf(Team team) =>
            from entity in _entities 
            let target = entity.Get<TeamMarker>().Team 
            where team.IsAlliesOf(target) select entity;

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