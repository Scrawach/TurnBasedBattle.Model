using System;
using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Commands.Abstract.Results;
using TurnBasedBattle.Model.Core.Components;
using TurnBasedBattle.Model.Core.Entities.Abstract;
using TurnBasedBattle.Model.Core.Extensions;

namespace TurnBasedBattle.Model.Commands.Implementations
{
    public sealed class InitiativeBurn : ICommand
    {
        public readonly IEntity Target;
        public readonly int Power;

        public InitiativeBurn(IEntity target, int power)
        {
            Target = target;
            Power = power;
        }

        public ICommandResult Execute(ICoreMechanics core)
        {
            if (Target.HasNot<Initiative>())
                return new Fail();
            
            var initiative = Target.Get<Initiative>();
            initiative.Value = Math.Max(0, initiative.Value - Power);
            return new Success();
        }

        public override string ToString() =>
            $"{Target} burn {Power} initiative";
    }
}