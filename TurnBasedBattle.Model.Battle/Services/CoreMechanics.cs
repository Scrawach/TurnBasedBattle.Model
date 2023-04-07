using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Core.Services.Characters.Abstract;

namespace TurnBasedBattle.Model.Battle.Services
{
    public sealed class CoreMechanics : ICoreMechanics
    {
        public CoreMechanics(ICharacterRegistry characters) =>
            Characters = characters;
        
        public ICharacterRegistry Characters { get; }
    }
}