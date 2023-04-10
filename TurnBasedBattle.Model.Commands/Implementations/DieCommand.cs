using TurnBasedBattle.Model.Commands.Abstract;
using TurnBasedBattle.Model.Commands.Abstract.Results;
using TurnBasedBattle.Model.Core.Entities.Abstract;

namespace TurnBasedBattle.Model.Commands.Implementations
{
    public sealed class DieCommand : ICommand
    {
        public readonly IEntity Target;

        public DieCommand(IEntity target) =>
            Target = target;
        
        public ICommandResult Execute(ICoreMechanics core)
        {
            core.Characters.Remove(Target);
            return new Success();
        }
        
        public override string ToString() =>
            $"{Target} died";
    }
}