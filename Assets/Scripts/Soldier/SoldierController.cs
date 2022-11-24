using UnityEngine;

public class SoldierController : MonoBehaviour
{
    protected StateMachine<SoldierController> _stateMachine;
    public SoldierIdle _idleState { get; private set; }
    public SoldierRunning _runningState { get; private set; }
    public SoldierShooting _shootingState { get; private set; }
    public SoldierCrouch _crouchingState { get; private set; }
    public SoldierCrouchShooting _crouchShootingState { get; private set; }


    protected virtual void Start()
    {
        _stateMachine = new StateMachine<SoldierController>();
        InitializeStates();
        _stateMachine.InitializeStateMachine(_idleState, this);
    }
    protected virtual void Update()
    {
        _stateMachine.CurrentState.OnUpdate();
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