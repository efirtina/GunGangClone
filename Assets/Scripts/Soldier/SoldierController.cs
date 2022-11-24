using UnityEngine;

public class SoldierController : MonoBehaviour
{
    private StateMachine<SoldierController> _stateMachine;
    private SoldierIdle _idleState;
    private SoldierRunning _runningState;
    private SoldierShooting _shootingState;
    private SoldierCrouch _crouchingState;
    private SoldierCrouchShooting _crouchShootingState;

    private void Start()
    {
        SetUpStateMachine();
    }
    private void Update()
    {
        _stateMachine.CurrentState.OnUpdate();
    }
    private void SetUpStateMachine() 
    {
        _stateMachine = new StateMachine<SoldierController>();
        InitializeStates();
        _stateMachine.InitializeStateMachine(_idleState, this);
    }
    private void InitializeStates()
    {
        _idleState = new SoldierIdle(_stateMachine);
        _runningState = new SoldierRunning(_stateMachine);
        _shootingState = new SoldierShooting(_stateMachine);
        _crouchingState = new SoldierCrouch(_stateMachine);
        _crouchShootingState = new SoldierCrouchShooting(_stateMachine);
    }


}
