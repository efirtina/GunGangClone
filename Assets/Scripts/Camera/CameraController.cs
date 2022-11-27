using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _followSpeed;
    private Transform _cameraTransform;
    private Vector3 _cameraPosition;

    private void Awake()
    {
        _cameraTransform = transform;
    }

    private void LateUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        if (_target == null) return;
        _cameraPosition = _target.position + _offset;
        _cameraPosition.x = 0f;
        _cameraTransform.position = Vector3.MoveTowards(_cameraTransform.position, _cameraPosition, Time.deltaTime * _followSpeed);
    }

    public void SetFollowSpeed(float value)
    {
        _followSpeed = value;
    }
}
