using TurnBasedBattle.Model.Core.Data;

namespace TurnBasedBattle.Model.Core.Extensions
{
    public static class TeamExtensions
    {
        public static bool IsAlliesOf(this Team self, Team target) =>
            self == target;

        public static bool IsEnemiesOf(this Team self, Team target) =>
            !self.IsAlliesOf(target);
    }
}