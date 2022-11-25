using UnityEngine;

public class PlayerController : SoldierController
{
    public PlayerShooting _playerShootingState { get; private set; }
    [field: SerializeField] public PlayerMovement _playerMovement { get; private set; }
    protected override void Start()
    {
        _stateMachine = new StateMachine<SoldierController>();
        InitializeStates();
        _playerShootingState = new PlayerShooting(_stateMachine);
        _stateMachine.InitializeStateMachine(_playerShootingState, this);
        SoldierManager.Instance.AddSoldierToList(this);
    }
}
