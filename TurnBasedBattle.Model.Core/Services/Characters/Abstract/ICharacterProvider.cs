using System.Collections.Generic;
using TurnBasedBattle.Model.Core.Entities.Abstract;

namespace TurnBasedBattle.Model.Core.Services.Characters.Abstract
{
    public interface ICharacterProvider
    {
        IEnumerable<IEntity> All();
        IEnumerable<IEntity> EnemiesOf(int teamId);
        IEnumerable<IEntity> AlliesOf(int teamId);
    }
}