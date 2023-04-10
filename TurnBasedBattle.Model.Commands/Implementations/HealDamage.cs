using System;
using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Commands.Abstract.Results;
using TurnBasedBattle.Model.Core.Components;
using TurnBasedBattle.Model.Core.Entities.Abstract;
using TurnBasedBattle.Model.Core.Extensions;

namespace TurnBasedBattle.Model.Commands.Implementations
{
    public sealed class HealDamage : ICommand
    {
        public readonly IEntity Target;
        public readonly int Power;

        public HealDamage(IEntity target, int power)
        {
            Target = target;
            Power = power;
        }
        
        public ICommandResult Execute(ICoreMechanics core)
        {
            if (Target.HasNot<Health>())
                return new Fail();

            var health = Target.Get<Health>();
            health.Value = Math.Min(health.Value + Power, health.Total);
            return new Success();
        }
        
        public override string ToString() => 
            $"{Target} heals {Power} healths";
    }
}