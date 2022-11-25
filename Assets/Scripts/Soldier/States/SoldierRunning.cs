using UnityEngine;

public class SoldierRunning : State<SoldierController>
{
    private Transform _targetTransform;

    public SoldierRunning(StateMachine<SoldierController> stateMachine) : base(stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _targetTransform = SoldierManager.Instance.GetFirstSoldier().transform;
        Debug.Log("test 3");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        Owner.RunToTarget(_targetTransform.position);
    }

    public override void DoChecks()
    {
        base.DoChecks();
        if(Vector3.Distance(Owner.SoldierTransform.position, _targetTransform.position) <= 1f)
        {
            Owner.SoldierTransform.parent = _targetTransform;
            StateMachine.ChangeState(Owner._shootingState);
        }
    }
}
