using UnityEngine;

public class SoldierDefeatIdle : State<SoldierController>
{
    public SoldierDefeatIdle(StateMachine<SoldierController> stateMachine) : base(stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Owner.SoldierRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        Owner.SoldierAnimator.SetTrigger("Defeat");
        //do some sad stuff
    }

}
