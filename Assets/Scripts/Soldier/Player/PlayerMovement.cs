using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _horizontalInput;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _leftBoundry;
    [SerializeField] private float _rightBoundry;
    private Vector3 _movementVector;

    private void Update()
    {
        GetInputs();
    }

    private void GetInputs()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    public void Move()
    {
        _movementVector.z += _forwardSpeed * Time.deltaTime;
        _movementVector.x += _horizontalInput * _horizontalSpeed * Time.deltaTime;
        _movementVector.x = Mathf.Clamp(_movementVector.x, _leftBoundry, _rightBoundry);
        transform.position = _movementVector;
    }
}
