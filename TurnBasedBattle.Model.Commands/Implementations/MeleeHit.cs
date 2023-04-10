using CodeBase.Model.TurnBasedBattle.Model.TurnBasedBattle.Model.Commands.Extensions;
using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Commands.Abstract.Results;
using TurnBasedBattle.Model.Core.Components;
using TurnBasedBattle.Model.Core.Entities.Abstract;
using TurnBasedBattle.Model.Core.Extensions;

namespace TurnBasedBattle.Model.Commands.Implementations
{
    public sealed class MeleeHit : ICommand
    {
        public readonly IEntity Attacker;
        public readonly IEntity Defender;

        public MeleeHit(IEntity attacker, IEntity defender)
        {
            Attacker = attacker;
            Defender = defender;
        }

        public ICommandResult Execute(ICoreMechanics core)
        {
            if (Attacker.HasNot<Fighting>())
                return new Fail();

            return new Result()
                .With(new DealDamage(Defender, Attacker.Get<Fighting>().Power))
                .With(new MeleeHit(Defender, Attacker), when: Defender.Has<CounterAttack>());
        }

        public override string ToString() => 
            $"{Attacker} attack {Defender} in melee";
    }
}