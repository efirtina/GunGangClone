using UnityEngine;

public class SoldierController : MonoBehaviour
{
    protected StateMachine<SoldierController> _stateMachine;

    #region States
    public SoldierIdle _idleState { get; private set; }
    public SoldierRunning _runningState { get; private set; }
    public SoldierShooting _shootingState { get; private set; }
    public SoldierCrouch _crouchingState { get; private set; }
    public SoldierCrouchShooting _crouchShootingState { get; private set; }
    public SoldierDefeatIdle _defeatIdle { get; private set; }
    public WellDeservedDance _danceState { get; private set; }
    #endregion

    [field: SerializeField] public SoldierFiring _soldierFiring { get; private set; }
    [field: SerializeField] public SoldierCollision _soldierCollision { get; private set; }
    public Transform SoldierTransform { get; private set; }
    public Rigidbody SoldierRigidbody { get; private set; }

    private void OnEnable()
    {
        GameManager.Instance.OnGameOver += ChangeStateToDefeatIdle;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameOver -= ChangeStateToDefeatIdle;
    }

    protected void Awake()
    {
        SoldierTransform = transform;
        SoldierRigidbody = GetComponent<Rigidbody>();
    }

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
    protected virtual void FixedUpdate()
    {
        _stateMachine.CurrentState.OnFixedUpdate();
    }
    protected void InitializeStates()
    {
        _idleState = new SoldierIdle(_stateMachine);
        _runningState = new SoldierRunning(_stateMachine);
        _shootingState = new SoldierShooting(_stateMachine);
        _crouchingState = new SoldierCrouch(_stateMachine);
        _defeatIdle = new SoldierDefeatIdle(_stateMachine);
        _crouchShootingState = new SoldierCrouchShooting(_stateMachine);
        _danceState = new WellDeservedDance(_stateMachine);
    }
    public void RunToTarget(Vector3 position)
    {
        transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * 4f);
    }
    public void RunToTarget(Vector3 position, float speed)
    {
        var direction = (position - transform.position).normalized;
        SoldierRigidbody.velocity = direction * speed;
    }
    public void ResetYPosition()
    {
        var pos = SoldierTransform.position;
        pos.y = 0f;
        SoldierTransform.position = pos;
    }
    public void ChangeState(State<SoldierController> newState)
    {
        _stateMachine.ChangeState(newState);
    }
    private void ChangeStateToDefeatIdle()
    {
        ChangeState(_defeatIdle);
    }
}
