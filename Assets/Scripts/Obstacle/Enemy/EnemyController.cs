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
        EnemyManager.Instance.OnEnemyKilled();
        EnemyManager.Instance.RemoveEnemyFromList(this);
        Destroy(this.gameObject);
    }
    public Vector3 GetMovingDirection()
    {
        return _movingDirection;
    }

    public void Move()
    {
        transform.DOMove(_targetPosition, _reachingTargetDuration)
            .OnComplete(OnReachedTarget.Invoke);
    }

    private void MoveLeft()
    {
        transform.DOMove(LevelManager.Instance.GetLeftPoint(), 2.5f)
            .OnComplete(MoveRight);
    }
    private void MoveRight()
    {
        transform.DOMove(LevelManager.Instance.GetRightPoint(), 2.5f)
            .OnComplete(MoveLeft);
    }
}
