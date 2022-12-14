using DG.Tweening;
using UnityEngine;

public class SoldierShooting : State<SoldierController>
{
    protected SoldierFiring _firing;

    public SoldierShooting(StateMachine<SoldierController> stateMachine) : base(stateMachine)
    {
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            SoldierManager.Instance.RemoveSoldierFromList(Owner);
            GameObject.Destroy(Owner.gameObject);
        }
    }

    public override void OnEnter()
{
        base.OnEnter();
        //Owner.SoldierAnimator.SetTrigger("Run");
        Owner.SoldierTransform.DORotate(Vector3.zero, 0.5f, RotateMode.Fast);
        if (!SoldierManager.Instance.IsContains(Owner))
        {
            SoldierManager.Instance.AddSoldierToList(Owner);
        }
        Owner.ResetYPosition();
        Owner.SoldierRigidbody.useGravity = false;
        Owner.SoldierRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        Owner._soldierCollision.SetTriggerStay(OnTriggerEnter);
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
        Owner._soldierCollision.SetTriggerStay(null);
        _firing.SetShootTimer(1f);
    }

    public override void DoChecks()
    {
        base.DoChecks();
        LevelManager.Instance.CheckIfFinish(Owner.SoldierTransform.position.z);
    }
}