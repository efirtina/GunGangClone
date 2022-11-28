using UnityEngine;

public class SoldierIdle : State<SoldierController>
{
    public SoldierIdle(StateMachine<SoldierController> stateMachine) : base(stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Owner._soldierCollision.SetCollisionEnter(OnCollisionEnter);
        Owner.SoldierAnimator.SetTrigger("Idle");
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            StateMachine.ChangeState(Owner._runningState);
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        Owner._soldierCollision.SetCollisionEnter(null);
    }
}
