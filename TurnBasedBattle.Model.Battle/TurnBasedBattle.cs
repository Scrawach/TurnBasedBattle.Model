using System.Threading.Tasks;
using TurnBasedBattle.Model.Battle.Abstract;
using TurnBasedBattle.Model.Battle.AI;
using TurnBasedBattle.Model.Battle.Commands;
using TurnBasedBattle.Model.Battle.Services;
using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Commands.Implementations;
using TurnBasedBattle.Model.Commands.Services.Abstract;
using TurnBasedBattle.Model.Core.Data;
using TurnBasedBattle.Model.Core.Factory;
using TurnBasedBattle.Model.Core.Factory.Abstract;
using TurnBasedBattle.Model.Core.Factory.Configs;
using TurnBasedBattle.Model.Core.Services.Characters.Abstract;

namespace TurnBasedBattle.Model.Battle
{
    public sealed class TurnBasedBattle
    {
        private const int InitiativePerTick = 1;

        private readonly ICommandExecutor _executor;
        private readonly ICoreMechanics _mechanics;
        private readonly IView _view;

        public TurnBasedBattle(ICommandExecutor executor, ICoreMechanics mechanics, IView view)
        {
            _executor = executor;
            _mechanics = mechanics;
            _view = view;
        }

        public async Task Process()
        {
            var characters = _mechanics.Characters;

            var player = new MeleeHitRepeater(characters, Team.Player);
            var enemy = new MeleeHitRepeater(characters, Team.Enemy);
            var battle = new BattleProcess(player, enemy);

            var config = new FighterConfig{Name = "Knight", Health = 10, Initiative = 5, Mana = 10, Power = 5};
            var fighterFactory = FighterFactory(config, characters);
            var playerFactory = new TeammateFactory(fighterFactory, Team.Player);
            var enemyFactory = new TeammateFactory(fighterFactory, Team.Enemy);
            
            await RunBattle(playerFactory, enemyFactory, battle);
        }

        private async Task RunBattle(IFactory playerFactory, IFactory enemyFactory, BattleProcess battle)
        {
            var player = playerFactory.Create();
            var battleResult = BattleResult.Unknown;
            while (battleResult != BattleResult.EnemyWin)
            {
                var enemy = enemyFactory.Create();
                _executor.Execute(new StartBattle(player, enemy));
                battleResult = BattleResult.Unknown;

                while (battleResult == BattleResult.Unknown)
                {
                    _executor.Execute(new Tick(InitiativePerTick));
                    battleResult = await battle.Process(_executor);
                    await _view.Update();
                }
                
                _executor.Execute(new HealDamage(player, 10));
            }
        }

        private static IFactory FighterFactory(FighterConfig config, ICharacterRegistry registry) =>
            new UniqueFactory
            (
                new RegisterFactory
                (
                    new FighterFactory(config), 
                    registry
                ),
                config.Name
            );
    }
}