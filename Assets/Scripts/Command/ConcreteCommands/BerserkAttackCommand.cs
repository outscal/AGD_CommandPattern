using Command.Actions;
using Command.Commands;
using Command.Main;

public class BerserkAttackCommand : UnitCommand
{
    private bool willHitTarget;

    public BerserkAttackCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();
    }

    public override bool WillHitTarget() => true;

    public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Attack).PerformAction(actorUnit, targetUnit, willHitTarget);
}