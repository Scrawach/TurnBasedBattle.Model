using System.Collections.Generic;
using TurnBasedBattle.Model.Core.Entities.Abstract;

namespace TurnBasedBattle.Model.Core.Services.Characters
{
    public interface ICharacterProvider
    {
        IEnumerable<IEntity> All();
    }
}