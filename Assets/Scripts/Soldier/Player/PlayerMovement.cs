using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _horizontalInput;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _horizontalSpeed;
    private float _boundry;
    private Vector3 _movementVector;
    private SoldierManager _soldierManager;

    private void Start()
    {
        _boundry = LevelManager.Instance.GetLevelBoundry();
        _soldierManager = SoldierManager.Instance;
    }

    public void GetInputs()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    public void Move()
    {
        _movementVector.z += _forwardSpeed * Time.deltaTime;
        _movementVector.x += _horizontalInput * _horizontalSpeed * Time.deltaTime;
        _movementVector.x = Mathf.Clamp(_movementVector.x, _boundry * -1f + CalculateLeftDiff(), _boundry + CalculateRightDiff());
        transform.position = _movementVector;
    }
    private float CalculateLeftDiff()
    {
        return transform.position.x - _soldierManager.GetLeftmostPosition().x;
    }
    private float CalculateRightDiff()
    {
        return transform.position.x - _soldierManager.GetRightmostPosition().x;
    }
}
