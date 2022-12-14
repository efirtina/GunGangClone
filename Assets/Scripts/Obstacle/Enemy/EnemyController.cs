using DG.Tweening;
using System;
using UnityEngine;

public class EnemyController : Obstacle
{
    [SerializeField] private float _reachingTargetDuration;
    private Vector3 _targetPosition;
    private Action OnReachedTarget;
    private Vector3 _oldPosition;
    private Vector3 _movingDirection;
    private bool _isDead;

    private void OnDisable()
    {
        DOTween.Kill(transform);
    }

    public void OnSpawn(int targetDirection)
    {
        var level = LevelManager.Instance;
        _oldPosition = transform.position;
        if(targetDirection == 0)
        {
            OnReachedTarget = MoveRight;
            _targetPosition = Vector3.Lerp(level.GetLeftPoint(), level.GetRightPoint(), 0.25f);
        }
        else
        {
            OnReachedTarget = MoveLeft;
            _targetPosition = Vector3.Lerp(level.GetLeftPoint(), level.GetRightPoint(), 0.75f);
        }
        Move();
    }

    private void LateUpdate()
    {
        _movingDirection = (transform.position - _oldPosition);
        _oldPosition = transform.position;
    }

    protected override void Explode()
    {
        if (_isDead) return;
        _isDead = true;
        EnemyManager.Instance.RemoveEnemyFromList(this);
        EnemyManager.Instance.OnEnemyKilled();
        Destroy(this.gameObject);
    }
    public Vector3 GetMovingDirection()
    {
        return _movingDirection;
    }
    
    public void Move()
    {
        transform.DOLookAt(_targetPosition, _reachingTargetDuration / 4f, default);
        transform.DOMove(_targetPosition, _reachingTargetDuration)
            .OnComplete(OnReachedTarget.Invoke);
    }

    private void MoveLeft()
    {
        transform.DOLookAt(LevelManager.Instance.GetLeftPoint(), _reachingTargetDuration / 4f, default);
        transform.DOMove(LevelManager.Instance.GetLeftPoint(), 2.5f)
            .OnComplete(MoveRight);
    }
    private void MoveRight()
    {
        transform.DOLookAt(LevelManager.Instance.GetRightPoint(), _reachingTargetDuration / 4f, default);
        transform.DOMove(LevelManager.Instance.GetRightPoint(), 2.5f)
            .OnComplete(MoveLeft);
    }
}
