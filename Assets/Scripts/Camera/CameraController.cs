using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
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
        _cameraPosition = _target.position + _offset;
        _cameraPosition.x = 0f;
        _cameraTransform.position = _cameraPosition;
    }
}
