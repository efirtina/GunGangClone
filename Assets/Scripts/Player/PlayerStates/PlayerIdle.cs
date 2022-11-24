using UnityEngine;

public class PlayerIdle : State<PlayerController>
{
    public PlayerIdle(StateMachine<PlayerController> stateMachine) : base(stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Owner.Idle();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StateMachine.ChangeState(Owner.MoveState);
        }
    }
}
