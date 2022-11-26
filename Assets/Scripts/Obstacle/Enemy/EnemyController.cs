using DG.Tweening;
using System;
using TMPro;
using UnityEngine;

public class EnemyController : Obstacle
{
    [SerializeField] private float _reachingTargetDuration;
    private Vector3 _targetPosition;
    //private int _targetDirection;
    private Action OnReachedTarget;

    private void OnDisable()
    {
        DOTween.Kill(transform);
    }

    public void OnSpawn(int targetDirection)
    {
        var level = LevelManager.Instance;
        //_targetDirection = targetDirection;
        if(targetDirection == 0)
        {
            OnReachedTarget = MoveLeft;
            _targetPosition = Vector3.Lerp(level.GetLeftPoint(), level.GetRightPoint(), 0.25f);
        }
        else
        {
            OnReachedTarget = MoveRight;
            _targetPosition = Vector3.Lerp(level.GetLeftPoint(), level.GetRightPoint(), 0.75f);
        }
        Move();
    }

    public void Move()
    {
        transform.DOMove(_targetPosition, _reachingTargetDuration)
            .OnComplete(OnReachedTarget.Invoke);
    }

    private void MoveLeft()
    {
        transform.DOMove(LevelManager.Instance.GetLeftPoint(), 3f)
            .OnComplete(MoveRight);
    }
    private void MoveRight()
    {
        transform.DOMove(LevelManager.Instance.GetRightPoint(), 3f)
            .OnComplete(MoveLeft);
    }
}
