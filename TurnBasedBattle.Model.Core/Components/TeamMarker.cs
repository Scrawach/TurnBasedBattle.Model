using TurnBasedBattle.Model.Core.Data;
using TurnBasedBattle.Model.Core.Entities.Abstract;

namespace TurnBasedBattle.Model.Core.Components
{
    public sealed class TeamMarker : IComponent
    {
        public TeamMarker(Team team) =>
            Team = team;
        
        public Team Team { get; }

        public override string ToString() =>
            $"Team = {Team}";
    }
}