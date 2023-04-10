using System;
using CodeBase.Model.TurnBasedBattle.Model.TurnBasedBattle.Model.Commands.Extensions;
using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Commands.Abstract.Results;
using TurnBasedBattle.Model.Core.Components;
using TurnBasedBattle.Model.Core.Entities.Abstract;
using TurnBasedBattle.Model.Core.Extensions;

namespace TurnBasedBattle.Model.Commands.Implementations
{
    public sealed class DealDamage : ICommand
    {
        public readonly IEntity Target;
        public readonly int Damage;

        public DealDamage(IEntity target, int damage)
        {
            Target = target;
            Damage = damage;
        }
        
        public ICommandResult Execute(ICoreMechanics core)
        {
            if (Target.HasNot<Health>())
                return new Fail();
        
            var health = Target.Get<Health>();
            health.Value = Math.Max(0, health.Value - Damage);

            return new Result()
                .With(new DieCommand(Target), when: health.Value == 0);
        }

        public override string ToString() =>
            $"{Target} takes {Damage} damage. {Target.Get<Health>()}";
    }
}