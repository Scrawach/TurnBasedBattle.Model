using System.Threading.Tasks;
using TurnBasedBattle.Model.Battle.AI.Abstract;
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
            if (_player.HasReadyEntity())
            {
                var decision = await _player.MakeDecision();
                executor.Execute(decision.Action);
            }

            if (_enemy.HasReadyEntity())
            {
                var decision = await _enemy.MakeDecision();
                executor.Execute(decision.Action);
            }

            if (_player.IsDefeated())
                return BattleResult.EnemyWin;

            if (_enemy.IsDefeated())
                return BattleResult.PlayerWin;

            return BattleResult.Unknown;
        }
    }
}