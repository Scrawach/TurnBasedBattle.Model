using CodeBase.Model.TurnBasedBattle.Model.TurnBasedBattle.Model.Commands.Extensions;
using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Commands.Abstract.Results;
using TurnBasedBattle.Model.Core.Components;
using TurnBasedBattle.Model.Core.Entities.Abstract;
using TurnBasedBattle.Model.Core.Extensions;

namespace TurnBasedBattle.Model.Commands.Implementations
{
    public sealed class InitiativeBurnFull : ICommand
    {
        public readonly IEntity Target;

        public InitiativeBurnFull(IEntity target) =>
            Target = target;
        
        public ICommandResult Execute(ICoreMechanics core)
        {
            if (Target.HasNot<Initiative>())
                return new Fail();

            return new Result(new InitiativeBurn(Target, Target.Get<Initiative>().Total));
        }

        public override string ToString() =>
            $"{Target} burn full initiative";
    }
}