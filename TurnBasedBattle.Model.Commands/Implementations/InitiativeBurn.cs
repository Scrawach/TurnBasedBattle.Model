using System;
using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Core.Components;
using TurnBasedBattle.Model.Core.Entities.Abstract;
using TurnBasedBattle.Model.Core.Extensions;

namespace TurnBasedBattle.Model.Commands.Implementations
{
    public sealed class InitiativeBurn : BaseCommand
    {
        public readonly IEntity Target;
        public readonly int Power;

        public InitiativeBurn(IEntity target, int power)
        {
            Target = target;
            Power = power;
        }

        protected override CommandStatus OnExecute(ICoreMechanics core)
        {
            if (Target.HasNot<Initiative>())
                return Fail();
            
            var initiative = Target.Get<Initiative>();
            initiative.Value = Math.Max(0, initiative.Value - Power);
            return Success();
        }

        public override string ToString() =>
            $"{Target} burn {Power} initiative";
    }
}