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
    private bool _canRotate = true;

    public WellDeservedDance(StateMachine<SoldierController> stateMachine) : base(stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _delay = 0.5f;
        _danceFloorRadius = LevelManager.Instance.GetDanceFloorRadius() / 2f;
        Owner.SoldierAnimator.SetTrigger("Idle");
        SetTargetPosition();
    }

    public override void OnUpdate()
    {
        if (_canRotate)
        {
            Owner.RotateTo(_targetPosition - Owner.SoldierTransform.position);
        }
        if (_isMoving) return;
        if (_timer >= _delay)
        {
            _canRotate = false;
            _isMoving = true;
            Owner.SoldierAnimator.SetTrigger("Run");
            Owner.SoldierTransform.DOMove(_targetPosition, 2f)
                .SetEase(Ease.Linear)
                .OnComplete(StartDancing);
        }
        _timer += Time.deltaTime;
    }

    private void SetTargetPosition()
    {
        _danceFloorPosition = LevelManager.Instance.GetDanceFloorPosition();
        _targetPosition = new Vector3(GetRandomNumber(), 0, GetRandomNumber()) + _danceFloorPosition;
        _targetPosition.y = 0f;

    }
    private float GetRandomNumber()
    {
        return Random.Range(-1 * _danceFloorRadius, _danceFloorRadius);
    }

    private void StartDancing()
    {
        Owner.SoldierAnimator.SetTrigger("Idle");
        Owner.SoldierTransform.DORotate(new Vector3(0f, 180f, 0f), 1f, RotateMode.Fast)
            .OnComplete(() => { Owner.SoldierAnimator.SetTrigger("Dance"); });
    }

}