using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private StateMachine<PlayerController> _stateMachine;
    public PlayerIdle IdleState { get; private set; }
    public PlayerMove MoveState { get; private set; }

    private void Start()
    {
        _stateMachine = new StateMachine<PlayerController>();
        InitializeStates();
        _stateMachine.InitializeStateMachine(IdleState, this);
    }
    private void Update()
    {
        _stateMachine.CurrentState.OnUpdate();
    }
    private void InitializeStates()
    {
        IdleState = new PlayerIdle(_stateMachine);
        MoveState = new PlayerMove(_stateMachine);
    }

    public void Move()
    {
        Debug.Log("Move");
    }

    public void Idle()
    {
        Debug.Log("Idle");
    }
}
