using UnityEngine;

public class PlayState : State<GameManager>
{
    public PlayState(StateMachine<GameManager> stateMachine) : base(stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Owner.OnGameStart?.Invoke();
    }
}
