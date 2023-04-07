using TurnBasedBattle.Model.Core.Components;
using TurnBasedBattle.Model.Core.Entities;
using TurnBasedBattle.Model.Core.Entities.Abstract;
using TurnBasedBattle.Model.Core.Factory.Abstract;
using TurnBasedBattle.Model.Core.Factory.Configs;

namespace TurnBasedBattle.Model.Core.Factory
{
    public sealed class FighterFactory : IFactory
    {
        private readonly FighterConfig _config;

        public FighterFactory(FighterConfig config) =>
            _config = config;

        public IEntity Create() =>
            new Entity()
                .Add(new Health(_config.Health))
                .Add(new Mana(_config.Mana))
                .Add(new Fighting(_config.Power))
                .Add(new Initiative(0, _config.Initiative));
    }
}