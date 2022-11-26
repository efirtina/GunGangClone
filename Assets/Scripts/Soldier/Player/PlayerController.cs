using UnityEngine;

public class PlayerController : SoldierController
{
    public PlayerShooting _playerShootingState { get; private set; }
    public PlayerIdle _playerIdleState { get; private set; }
    [field: SerializeField] public PlayerMovement _playerMovement { get; private set; }

    private void OnEnable()
    {
        GameManager.Instance.OnGameStart += StartShooting;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnGameStart -= StartShooting;
    }

    protected override void Start()
    {
        _stateMachine = new StateMachine<SoldierController>();
        InitializeStates();
        _playerShootingState = new PlayerShooting(_stateMachine);
        _playerIdleState = new PlayerIdle(_stateMachine);
        _stateMachine.InitializeStateMachine(_playerIdleState, this);
    }

    protected override void Update()
    {
        base.Update();
        UIManager.Instance.UpdateProgressBar(SoldierTransform.position.z / LevelManager.Instance.GetFinishZ());
    }

    private void StartShooting()
    {
        _stateMachine.ChangeState(_playerShootingState);
    }
}
