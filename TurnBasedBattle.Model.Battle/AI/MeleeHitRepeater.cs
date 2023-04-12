using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurnBasedBattle.Model.Battle.AI.Abstract;
using TurnBasedBattle.Model.Commands.Implementations;
using TurnBasedBattle.Model.Core.Components;
using TurnBasedBattle.Model.Core.Data;
using TurnBasedBattle.Model.Core.Entities.Abstract;
using TurnBasedBattle.Model.Core.Services.Characters.Abstract;

namespace TurnBasedBattle.Model.Battle.AI
{
    public sealed class MeleeHitRepeater : IPlayer
    {
        private readonly ICharacterProvider _characters;
        private readonly Team _team;

        public MeleeHitRepeater(ICharacterProvider characters, Team team)
        {
            _characters = characters;
            _team = team;
        }
        
        public bool IsDefeated() =>
            !_characters.AlliesOf(_team).Any();

        public bool HasReadyEntity() =>
            ReadyCharacter().Any();

        public Task<Decision> MakeDecision()
        {
            var self = ReadyCharacter().First();
            var target = _characters.EnemiesOf(_team).First();
            return Task.FromResult(new Decision(self, new MeleeHit(self, target)));
        }

        private IEnumerable<IEntity> ReadyCharacter() =>
            _characters
                .AlliesOf(_team)
                .Where(entity => entity.Get<Initiative>().IsFull());
    }
}