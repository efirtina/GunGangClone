using UnityEngine;

public class SoldierController : MonoBehaviour
{
    protected StateMachine<SoldierController> _stateMachine;
    protected SoldierIdle _idleState;
    protected SoldierRunning _runningState;
    protected SoldierShooting _shootingState;
    protected SoldierCrouch _crouchingState;
    protected SoldierCrouchShooting _crouchShootingState;

    protected void Awake()
    {
        _stateMachine = new StateMachine<SoldierController>();
        InitializeStates();
    }
    protected virtual void Start()
    {
        _stateMachine.InitializeStateMachine(_idleState, this);
    }
    protected virtual void Update()
    {
        _stateMachine.CurrentState.OnUpdate();
        Debug.Log(_stateMachine.CurrentState);
    }
    protected void InitializeStates()
    {
        _idleState = new SoldierIdle(_stateMachine);
        _runningState = new SoldierRunning(_stateMachine);
        _shootingState = new SoldierShooting(_stateMachine);
        _crouchingState = new SoldierCrouch(_stateMachine);
        _crouchShootingState = new SoldierCrouchShooting(_stateMachine);
    }
}
