using System;
using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Core.Components;
using TurnBasedBattle.Model.Core.Entities.Abstract;
using TurnBasedBattle.Model.Core.Extensions;

namespace TurnBasedBattle.Model.Commands.Implementations
{
    public sealed class IncreaseInitiative : BaseCommand
    {
        public readonly IEntity Target;
        public readonly int Power;

        public IncreaseInitiative(IEntity target, int power)
        {
            Target = target;
            Power = power;
        }
        
        protected override CommandStatus OnExecute(ICoreMechanics core)
        {
            if (Target.HasNot<Initiative>())
                return Fail();

            var initiative = Target.Get<Initiative>();
            initiative.Value = Math.Min(initiative.Value + Power, initiative.Total);
            return Success();
        }
    }
}