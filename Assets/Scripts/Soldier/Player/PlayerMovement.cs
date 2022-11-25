using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _horizontalInput;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _horizontalSpeed;
    private float _boundry;
    private float _leftDiff;
    private float _rightDiff;
    private Vector3 _movementVector;
    private SoldierManager _soldierManager;

    private void OnEnable()
    {
        _soldierManager.OnSoldierAdded += CalculateDiffs;
        _soldierManager.OnSoldierDestroy += CalculateDiffs;     
    }
    private void OnDisable()
    {
        _soldierManager.OnSoldierAdded -= CalculateDiffs;
        _soldierManager.OnSoldierDestroy -= CalculateDiffs;
    }

    private void Awake()
    {
        _soldierManager = SoldierManager.Instance;
    }

    private void Start()
    {
        _boundry = LevelManager.Instance.GetLevelBoundry();
    }

    public void GetInputs()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    public void Move()
    {
        _movementVector.z += _forwardSpeed * Time.deltaTime;
        _movementVector.x += _horizontalInput * _horizontalSpeed * Time.deltaTime;
        _movementVector.x = Mathf.Clamp(_movementVector.x, _boundry * -1f + _leftDiff, _boundry + _rightDiff);
        transform.position = _movementVector;
    }
    private void CalculateDiffs()
    {
        _leftDiff = transform.position.x - _soldierManager.GetLeftmostPosition().x;
        _rightDiff = transform.position.x - _soldierManager.GetRightmostPosition().x;
    }
}
