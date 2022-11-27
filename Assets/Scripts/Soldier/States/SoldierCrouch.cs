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
        if(Vector3.Distance(targetPosition, Owner.SoldierTransform.position) <= 0.05f)
        {
            StateMachine.ChangeState(Owner._crouchShootingState);
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        SoldierManager.Instance.NumberOfSoldiersGotCover += 1;
    }

    public void SetTargetPosition(Vector3 newTarget)
    {
        targetPosition = newTarget;
    }
}
