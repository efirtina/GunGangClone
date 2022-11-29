using UnityEngine;

public class PlayState : State<GameManager>
{
    private bool _isWin;
    public PlayState(StateMachine<GameManager> stateMachine) : base(stateMachine)
    {
    }

    public override void OnEnter()
    {
        Owner.OnGameStart?.Invoke();
    }

    public override void DoChecks()
    {
        if (_isWin)
        {
            StateMachine.ChangeState(Owner._winState);
        }
    }

    public void SetIsWin(bool value)
    {
        _isWin = value;
    }
}
