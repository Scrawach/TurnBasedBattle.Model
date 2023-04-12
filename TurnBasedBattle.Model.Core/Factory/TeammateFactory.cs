using TurnBasedBattle.Model.Core.Components;
using TurnBasedBattle.Model.Core.Data;
using TurnBasedBattle.Model.Core.Entities.Abstract;
using TurnBasedBattle.Model.Core.Factory.Abstract;

namespace TurnBasedBattle.Model.Core.Factory
{
    public sealed class TeammateFactory : IFactory
    {
        private readonly IFactory _origin;
        private readonly Team _team;

        public TeammateFactory(IFactory origin, Team team)
        {
            _origin = origin;
            _team = team;
        }

        public IEntity Create() =>
            _origin.Create()
                .Add(new TeamMarker(_team));
    }
}