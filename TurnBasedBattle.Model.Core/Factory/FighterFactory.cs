using TurnBasedBattle.Model.Core.Components;
using TurnBasedBattle.Model.Core.Entities;
using TurnBasedBattle.Model.Core.Entities.Abstract;
using TurnBasedBattle.Model.Core.Factory.Abstract;

namespace TurnBasedBattle.Model.Core.Factory
{
    public sealed class FighterFactory : IFactory
    {
        private readonly int _health;
        private readonly int _mana;
        private readonly int _fighting;
        private readonly int _initiative;

        public FighterFactory(int health, int mana, int fighting, int initiative)
        {
            _health = health;
            _mana = mana;
            _fighting = fighting;
            _initiative = initiative;
        }

        public IEntity Create() =>
            new Entity()
                .Add(new Health(_health))
                .Add(new Mana(_mana))
                .Add(new Fighting(_fighting))
                .Add(new Initiative(0, _initiative));
    }
}