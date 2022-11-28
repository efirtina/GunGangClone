using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _followSpeed;
    private bool _canEnjoyDanceShow;
    private Transform _finalTarget;
    private Transform _cameraTransform;
    private Vector3 _cameraPosition;

    private void OnEnable()
    {
        EnemyManager.Instance.OnAllEnemiesKilled += SetCanEnjoyDanceShowTrue;
    }

    private void OnDisable()
    {
        EnemyManager.Instance.OnAllEnemiesKilled -= SetCanEnjoyDanceShowTrue;
    }

    private void Start()
    {
        _cameraTransform = transform;
        _finalTarget = LevelManager.Instance.transform.GetChild(0).transform.GetChild(0);
    }

    private void LateUpdate()
    {
        if(!_canEnjoyDanceShow)
        {
            FollowTarget();
        }
        else
        {
            EnjoyDanceShow();
        }
    }

    private void FollowTarget()
    {
        if (_target == null) return;
        _cameraPosition = _target.position + _offset;
        _cameraPosition.x = 0f;
        _cameraTransform.position = Vector3.MoveTowards(_cameraTransform.position, _cameraPosition, Time.deltaTime * _followSpeed);
    }

    private void SetCanEnjoyDanceShowTrue()
    {
        _canEnjoyDanceShow = true;
    }

    private void EnjoyDanceShow()
    {
        var direction = _finalTarget.position - transform.position;
        var toRotation = Quaternion.FromToRotation(transform.forward, direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * 1f);
    }

    public void SetFollowSpeed(float value)
    {
        _followSpeed = value;
    }
}
