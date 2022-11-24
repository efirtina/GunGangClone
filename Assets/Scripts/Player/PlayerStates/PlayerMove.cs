using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : State<PlayerController>
{
    public PlayerMove(StateMachine<PlayerController> stateMachine) : base(stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Owner.Move();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StateMachine.ChangeState(Owner.IdleState);
        }
    }
}
