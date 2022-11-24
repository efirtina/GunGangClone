using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _horizontalInput;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _horizontalSpeed;
    private float _boundry;
    private Vector3 _movementVector;

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
        _movementVector.x = Mathf.Clamp(_movementVector.x, _boundry * -1f, _boundry);
        transform.position = _movementVector;
    }
}
