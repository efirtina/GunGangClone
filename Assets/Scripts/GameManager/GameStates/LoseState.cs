using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseState : State<GameManager>
{
    public LoseState(StateMachine<GameManager> stateMachine) : base(stateMachine)
    {
    }

    public override void OnEnter()
    {
        UIManager.Instance.SetActiveLosePanel(true);
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
        UIManager.Instance.SetActiveLosePanel(false);
    }
}
