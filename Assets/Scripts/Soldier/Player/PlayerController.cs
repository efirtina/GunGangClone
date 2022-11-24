using UnityEngine;

public class PlayerController : SoldierController
{
    private PlayerShooting _playerShootingState;
    [field: SerializeField] public PlayerMovement _playerMovement { get; private set; }
    protected override void Start()
    {
        _stateMachine = new StateMachine<SoldierController>();
        InitializeStates();
        _playerShootingState = new PlayerShooting(_stateMachine);
        _stateMachine.InitializeStateMachine(_playerShootingState, this);
        SoldierManager.Instance.AddSoldierToList(this);
    }

    protected override void Update()
    {
        base.Update();
    }
}
