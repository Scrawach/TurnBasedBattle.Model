using System.Collections.Generic;
using TurnBasedBattle.Model.Core.Components;
using TurnBasedBattle.Model.Core.Data;
using TurnBasedBattle.Model.Core.Entities.Abstract;

namespace TurnBasedBattle.Model.Core.Services.Characters.Abstract
{
    public interface ICharacterProvider
    {
        IEnumerable<IEntity> All();
        IEnumerable<IEntity> EnemiesOf(Team team);
        IEnumerable<IEntity> AlliesOf(Team team);
    }
}