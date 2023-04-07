using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Core.Components;
using TurnBasedBattle.Model.Core.Entities.Abstract;
using TurnBasedBattle.Model.Core.Extensions;

namespace TurnBasedBattle.Model.Commands.Implementations
{
    public sealed class InitiativeBurnFull : BaseCommand
    {
        public readonly IEntity Target;

        public InitiativeBurnFull(IEntity target) =>
            Target = target;
        
        protected override CommandStatus OnExecute(ICoreMechanics core)
        {
            if (Target.HasNot<Initiative>())
                return Fail();

            var initiative = Target.Get<Initiative>();
            Children.Add(new InitiativeBurn(Target, initiative.Total));
            return Success();
        }

        public override string ToString() =>
            $"{Target} burn full initiative";
    }
}