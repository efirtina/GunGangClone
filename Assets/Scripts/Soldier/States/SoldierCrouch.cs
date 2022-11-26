using UnityEngine;

public class SoldierCrouch : State<SoldierController>
{
    private Vector3 targetPosition;
    public SoldierCrouch(StateMachine<SoldierController> stateMachine) : base(stateMachine)
    {
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        Owner.RunToTarget(targetPosition);
    }

    public void SetTargetPosition(Vector3 newTarget)
    {
        targetPosition = newTarget;
    }
}
