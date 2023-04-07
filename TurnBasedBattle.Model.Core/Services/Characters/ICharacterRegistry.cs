using System;
using TurnBasedBattle.Model.Core.Entities.Abstract;

namespace TurnBasedBattle.Model.Core.Services.Characters
{
    public interface ICharacterRegistry : IDisposable
    {
        ICharacterRegistry Add(IEntity character);
        ICharacterRegistry Remove(IEntity character);
    }
}