using System.Threading.Tasks;
using TurnBasedBattle.Model.Battle.Abstract;
using TurnBasedBattle.Model.Battle.AI;
using TurnBasedBattle.Model.Battle.Commands;
using TurnBasedBattle.Model.Battle.Services;
using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Commands.Implementations;
using TurnBasedBattle.Model.Commands.Services;
using TurnBasedBattle.Model.Core.Factory;
using TurnBasedBattle.Model.Core.Factory.Abstract;
using TurnBasedBattle.Model.Core.Factory.Configs;
using TurnBasedBattle.Model.Core.Services.Characters;
using TurnBasedBattle.Model.Core.Services.Characters.Abstract;
using TurnBasedBattle.Model.EventBus.Abstract;

namespace TurnBasedBattle.Model.Battle
{
    public class TurnBasedBattle
    {
        private const int PlayerTeamId = 0;
        private const int EnemyTeamId = 1;
        private const string FighterPrefix = "Knight";
        private const int InitiativePerTick = 1;

        private readonly IEventBus<ICommand> _bus;
        private readonly IView _view;

        public TurnBasedBattle(IEventBus<ICommand> bus, IView view)
        {
            _bus = bus;
            _view = view;
        }

        public async Task Process()
        {
            var characters = new CharacterRegistry();
            var mechanics = new CoreMechanics(characters);

            var executor = new CommandExecutor(_bus, mechanics);

            var player = new MeleeHitRepeater(characters, PlayerTeamId);
            var enemy = new MeleeHitRepeater(characters, EnemyTeamId);
            var battle = new BattleProcess(player, enemy);

            var config = new FighterConfig{Health = 10, Initiative = 10, Mana = 10, Power = 2};
            var playerUnitFactory = FighterFactory(config, characters, PlayerTeamId, FighterPrefix);
            var enemyUnitFactory = FighterFactory(config, characters, EnemyTeamId, FighterPrefix);
            
            executor.Execute(new Spawn(playerUnitFactory));
            var battleResult = BattleResult.Unknown;

            while (battleResult != BattleResult.EnemyWin)
            {
                executor.Execute(new Spawn(enemyUnitFactory));
                battleResult = BattleResult.Unknown;

                while (battleResult == BattleResult.Unknown)
                {
                    executor.Execute(new Tick(InitiativePerTick));
                    battleResult = await battle.Process(executor);
                    await _view.Update();
                }
            }
        }

        private static IFactory FighterFactory(FighterConfig config, ICharacterRegistry registry, int teamId, string prefix) =>
            new UniqueFactory
            (
                new TeammateFactory
                (
                    new RegisterFactory
                    (
                        new FighterFactory(config), 
                        registry
                    ),
                    teamId
                ),
                prefix
            );
    }
}