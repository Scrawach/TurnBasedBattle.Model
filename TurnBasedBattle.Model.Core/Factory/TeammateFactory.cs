using TurnBasedBattle.Model.Core.Components;
using TurnBasedBattle.Model.Core.Entities.Abstract;
using TurnBasedBattle.Model.Core.Factory.Abstract;

namespace TurnBasedBattle.Model.Core.Factory
{
    public sealed class TeammateFactory : IFactory
    {
        private readonly IFactory _origin;
        private readonly int _teamId;

        public TeammateFactory(IFactory origin, int teamId)
        {
            _origin = origin;
            _teamId = teamId;
        }

        public IEntity Create() =>
            _origin.Create()
                .Add(new TeamMarker(_teamId));
    }
}