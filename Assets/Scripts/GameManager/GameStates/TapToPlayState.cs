using UnityEngine;

public class TapToPlayState : State<GameManager>
{
    public TapToPlayState(StateMachine<GameManager> stateMachine) : base(stateMachine)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StateMachine.ChangeState(Owner._playState);
        }
    }
}
