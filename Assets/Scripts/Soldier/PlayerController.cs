using UnityEngine;

public class PlayerController : SoldierController
{
    private PlayerShooting _playerShootingState;
    protected override void Start()
    {
        _stateMachine = new StateMachine<SoldierController>();
        InitializeStates();
        _playerShootingState = new PlayerShooting(_stateMachine);
        _stateMachine.InitializeStateMachine(_playerShootingState, this);
    }

    protected override void Update()
    {
        base.Update();
        Debug.Log(_stateMachine.CurrentState);
    }
}
