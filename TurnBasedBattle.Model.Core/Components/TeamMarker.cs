using TurnBasedBattle.Model.Core.Entities.Abstract;

namespace TurnBasedBattle.Model.Core.Components
{
    public sealed class TeamMarker : IComponent
    {
        public TeamMarker(int teamId) =>
            TeamId = teamId;
        
        public int TeamId { get; }

        public override string ToString() =>
            $"Team = {TeamId}";
    }
}