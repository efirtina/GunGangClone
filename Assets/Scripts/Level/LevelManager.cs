using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    private Vector3 _leftPoint;
    private Vector3 _rightPoint;
    [SerializeField] private Transform _groundTransform;
    [SerializeField] private Transform _finishLine;
    [SerializeField] private Transform _endPlatform;
    private bool _isSomeoneReachedFinish;
    private bool _canInvokeEvent = true;
    private float _minDistanceToFinish;
    public Action OnFinish;

    public bool IsSomeoneReachedFinish
    {
        get
        {
            return _isSomeoneReachedFinish;
        }
        set
        {
            _isSomeoneReachedFinish = value;
            if (_isSomeoneReachedFinish && _canInvokeEvent)
            {
                _canInvokeEvent = false;
                OnFinish?.Invoke();
            }
        }
    }

    private void Awake()
    {
        Instance = this;
        _minDistanceToFinish = 4f;
        _leftPoint = new Vector3(GetLevelBoundry() * -1, 0f, _finishLine.position.z);
        _rightPoint = _leftPoint;
        _rightPoint.x *= -1f;
    }

    public float GetLevelBoundry()
    {
        return _groundTransform.localScale.x / 2;
    }

    public void CheckIfFinish(float zPosition)
    {
        if(_finishLine.position.z - zPosition <= _minDistanceToFinish)
        {
            IsSomeoneReachedFinish = true;
        }
    }
    public float GetFinishZ()
    {
        return _finishLine.position.z - _minDistanceToFinish;
    }

    public Vector3 GetLeftPoint()
    {
        return _leftPoint;
    }

    public Vector3 GetRightPoint()
    {
        return _rightPoint;
    }

    public Vector3 GetDanceFloorPosition()
    {
        return _endPlatform.position;
    }
    public float GetDanceFloorRadius()
    {
        return _groundTransform.lossyScale.x / 2f;
    }

    public void SetCrouchingPositionsAndChangeStates(List<SoldierController> soldiers)
    {
        SoldierCrouch stateInstance;
        float interpolator = 1f / soldiers.Count / 2f;
        for (int i = 0; i < soldiers.Count; i++)
        {
            stateInstance = soldiers[i]._crouchingState;
            stateInstance.SetTargetPosition(Vector3.Lerp(_leftPoint, _rightPoint, interpolator));
            soldiers[i].transform.SetParent(null);
            soldiers[i].ChangeState(soldiers[i]._crouchingState);
            interpolator += 1f / soldiers.Count;
        }
    }
}
