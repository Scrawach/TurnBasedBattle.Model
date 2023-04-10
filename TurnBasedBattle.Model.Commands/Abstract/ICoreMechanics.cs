using TurnBasedBattle.Model.Core.Services.Characters.Abstract;

namespace TurnBasedBattle.Model.Commands.Abstract
{
    public interface ICoreMechanics
    {
        ICharacterRegistry Characters { get; }
    }
}