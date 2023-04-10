using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Commands.Abstract.Results;
using TurnBasedBattle.Model.Core.Entities.Abstract;

namespace TurnBasedBattle.Model.Commands.Implementations
{
    public sealed class VampireHit : ICommand
    {
        public readonly IEntity Attacker;
        public readonly IEntity Defender;
        public readonly int Power;

        public VampireHit(IEntity attacker, IEntity defender, int power)
        {
            Attacker = attacker;
            Defender = defender;
            Power = power;
        }

        public ICommandResult Execute(ICoreMechanics core) =>
            new Result
            (
                new DealDamage(Defender, Power), 
                new HealDamage(Attacker, Power)
            );
    }
}