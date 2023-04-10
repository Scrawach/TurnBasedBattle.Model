using System;
using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Commands.Abstract.Results;
using TurnBasedBattle.Model.Core.Components;
using TurnBasedBattle.Model.Core.Entities.Abstract;
using TurnBasedBattle.Model.Core.Extensions;

namespace TurnBasedBattle.Model.Commands.Implementations
{
    public sealed class IncreaseInitiative : ICommand
    {
        public readonly IEntity Target;
        public readonly int Power;

        public IncreaseInitiative(IEntity target, int power)
        {
            Target = target;
            Power = power;
        }
        
        public ICommandResult Execute(ICoreMechanics core)
        {
            if (Target.HasNot<Initiative>())
                return new Fail();

            var initiative = Target.Get<Initiative>();
            initiative.Value = Math.Min(initiative.Value + Power, initiative.Total);
            return new Success();
        }
        
        public override string ToString() =>
            $"{Target} take {Power} initiative ";
    }
}