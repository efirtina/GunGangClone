using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : State<GameManager>
{
    public WinState(StateMachine<GameManager> stateMachine) : base(stateMachine)
    {
    }

    public override void OnEnter()
    {
        Owner.OnWin?.Invoke();
        UIManager.Instance.SetActiveWinPanel(true);
    }

    public override void DoChecks()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }

    public override void OnExit()
    {
        UIManager.Instance.SetActiveWinPanel(false);
    }
}
