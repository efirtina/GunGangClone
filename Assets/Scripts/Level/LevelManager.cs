using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private Transform _groundTransform;
    [SerializeField] private Transform _finishLine;
    private bool _isSomeoneReachedFinish;
    private bool _canInvokeEvent = true;
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
    }

    public float GetLevelBoundry()
    {
        return _groundTransform.localScale.x / 2;
    }

    public void CheckIfFinish(float zPosition)
    {
        if(_finishLine.position.z - zPosition <= 4f)
        {
            IsSomeoneReachedFinish = true;
        }
    }

    public void SetCrouchingPositionsAndChangeStates(List<SoldierController> soldiers)
    {
        var leftPoint = new Vector3(GetLevelBoundry() * -1, 0f, _finishLine.position.z);
        var rightPoint = leftPoint;
        rightPoint.x *= -1f;
        SoldierCrouch stateInstance;
        Vector3 direction = (rightPoint - leftPoint);
        Vector3 pos = leftPoint + direction / (soldiers.Count * 2);
        for (int i = 0; i < soldiers.Count; i++)
        {
            stateInstance = soldiers[i]._crouchingState;
            stateInstance.SetTargetPosition(pos);
            soldiers[i].ChangeState(soldiers[i]._crouchingState);
            pos += direction / soldiers.Count;
        }
    }
}
