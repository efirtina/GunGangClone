using UnityEngine;

public class SoldierShooting : State<SoldierController>
{
    protected SoldierFiring _firing;

    public SoldierShooting(StateMachine<SoldierController> stateMachine) : base(stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        SoldierManager.Instance.AddSoldierToList(Owner);
        Owner.ResetYPosition();
        Owner.SoldierRigidbody.useGravity = false;
        Owner.SoldierRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        Owner._soldierCollision.SetIsTrigger(true);
        if(_firing == null)
        {
            _firing = Owner._soldierFiring;
        }
        _firing.ResetShootTimer();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        _firing.DoCountdown();
        _firing.Shoot();
    }

    public override void OnExit()
    {
        base.OnExit();
        Owner._soldierCollision.SetTriggerEnter(null);
        _firing.SetShootTimer(1f);
    }

    public override void DoChecks()
    {
        base.DoChecks();
        LevelManager.Instance.CheckIfFinish(Owner.SoldierTransform.position.z);
    }
}