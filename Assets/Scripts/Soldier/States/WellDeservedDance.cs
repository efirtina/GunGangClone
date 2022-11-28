using DG.Tweening;
using UnityEngine;

public class WellDeservedDance : State<SoldierController>
{
    private float _delay;
    private float _timer;
    private bool _isMoving;
    private Vector3 _targetPosition;
    private Vector3 _danceFloorPosition;
    private float _danceFloorRadius;

    public WellDeservedDance(StateMachine<SoldierController> stateMachine) : base(stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _delay = 0.5f;
        _danceFloorRadius = LevelManager.Instance.GetDanceFloorRadius();
        SetTargetPosition();
    }

    public override void OnUpdate()
    {
        if (_isMoving) return;
        if (_timer >= _delay)
        {
            Owner.SoldierTransform.DOMove(_targetPosition, 2f)
                .SetEase(Ease.Linear)
                .OnComplete(StartDancing);
            _isMoving = true;
        }
        _timer += Time.deltaTime;
    }

    private void SetTargetPosition()
    {
        _danceFloorPosition = LevelManager.Instance.GetDanceFloorPosition();
        _targetPosition = new Vector3(GetRandomNumber(), 0f, GetRandomNumber()) + _danceFloorPosition;

    }
    private float GetRandomNumber()
    {
        return Random.Range(-1 * _danceFloorRadius, _danceFloorRadius);
    }

    private void StartDancing()
    {

    }

}