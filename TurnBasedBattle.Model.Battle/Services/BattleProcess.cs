using System.Threading.Tasks;
using TurnBasedBattle.Model.Battle.AI.Abstract;
using TurnBasedBattle.Model.Battle.Commands;
using TurnBasedBattle.Model.Commands.Services.Abstract;

namespace TurnBasedBattle.Model.Battle.Services
{
    public sealed class BattleProcess
    {
        private readonly IPlayer _player;
        private readonly IPlayer _enemy;

        public BattleProcess(IPlayer player, IPlayer enemy)
        {
            _player = player;
            _enemy = enemy;
        }

        public async Task<BattleResult> Process(ICommandExecutor executor)
        {
            await MakeTurn(_player, executor);
            await MakeTurn(_enemy, executor);
            return ChoiceResult(_player.IsDefeated(), _enemy.IsDefeated());
        }

        private static async Task MakeTurn(IPlayer player, ICommandExecutor executor)
        {
            if (!player.HasReadyEntity())
                return;

            var decision = await player.MakeDecision();
            executor.Execute(new StartTurn(decision.Actor, decision.Action));
        }

        private static BattleResult ChoiceResult(bool isPlayerDefeated, bool isEnemyDefeated)
        {
            if (isPlayerDefeated)
                return BattleResult.EnemyWin;

            if (isEnemyDefeated)
                return BattleResult.PlayerWin;

            return BattleResult.Unknown;
        }
    }
}