using System.Threading.Tasks;

namespace TurnBasedBattle.Model.Battle.Abstract
{
    public interface IView
    {
        Task Update();
    }
}