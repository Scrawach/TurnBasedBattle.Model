using TurnBasedBattle.Model.Core.Services.Characters;

namespace TurnBasedBattle.Model.Commands.Implementations
{
    public interface ICoreMechanics
    {
        ICharacterRegistry Characters { get; }
    }
}