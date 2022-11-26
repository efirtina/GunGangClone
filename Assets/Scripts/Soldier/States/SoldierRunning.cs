using UnityEngine;

public class SoldierRunning : State<SoldierController>
{
    private Transform _targetTransform;
    private bool _isReachedToTarget;

    public SoldierRunning(StateMachine<SoldierController> stateMachine) : base(stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        var rigidbody = Owner.SoldierRigidbody;
        rigidbody.velocity = Vector3.zero;
        rigidbody.useGravity = false;
        _targetTransform = SoldierManager.Instance.GetFirstSoldier().transform;
        Owner._soldierCollision.SetTriggerEnter(OnTriggerEnter);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Soldier")) return;
        if (!SoldierManager.Instance.IsContains(other.GetComponent<SoldierController>())) return;
        _isReachedToTarget = true;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        //Owner.RunToTarget(_targetTransform.position);
    }
    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        Owner.RunToTarget(_targetTransform.position, 10f);
    }

    public override void OnExit()
    {
        base.OnExit();
        Owner._soldierCollision.SetCollisionEnter(null);
    }

    public override void DoChecks()
    {
        base.DoChecks();
        if(_isReachedToTarget)
        {
            Owner.SoldierTransform.parent = _targetTransform;
            StateMachine.ChangeState(Owner._shootingState);
        }
    }
}
