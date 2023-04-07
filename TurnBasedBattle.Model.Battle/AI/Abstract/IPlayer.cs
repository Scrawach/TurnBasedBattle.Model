using System.Threading.Tasks;

namespace TurnBasedBattle.Model.Battle.AI.Abstract
{
    public interface IPlayer
    {
        bool IsDefeated();
        bool HasReadyEntity();
        Task<Decision> MakeDecision();
    }
}