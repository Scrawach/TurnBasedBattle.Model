using System;
using TurnBasedBattle.Model.Core.Entities.Abstract;

namespace TurnBasedBattle.Model.Core.Services.Characters.Abstract
{
    public interface ICharacterRegistry : ICharacterProvider, IDisposable
    {
        ICharacterRegistry Add(IEntity character);
        ICharacterRegistry Remove(IEntity character);
    }
}