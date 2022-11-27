using UnityEngine;

public class SoldierCrouchShooting : SoldierShooting
{
    private bool _canShoot;
    public SoldierCrouchShooting(StateMachine<SoldierController> stateMachine) : base(stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _canShoot = SoldierManager.Instance.CanLastGuyShoot();
        SoldierManager.Instance.OnEverySoldierGotCover += LetSoldierShoot;
    }

    public override void OnUpdate()
    {
        if (!_canShoot) return;
        Owner.SoldierTransform.rotation = Quaternion.LookRotation(CalculateFacingDirection());
        _firing.DoCountdown();
        _firing.Shoot(CalculateProjectileDirection());
    }

    public override void OnExit()
    {
        base.OnExit();
        SoldierManager.Instance.OnEverySoldierGotCover -= LetSoldierShoot;
    }

    private Vector3 CalculateProjectileDirection()
    {
        var direction = (EnemyManager.Instance.GetNextEnemyPosition() - Owner._soldierFiring.GetGunPosition());
        direction.y += Owner._soldierFiring.GetGunYPosition();
        direction += EnemyManager.Instance.GetNextEnemyMovingDirection() * 1.5f;
        direction.Normalize();
        return direction;
    }

    private Vector3 CalculateFacingDirection()
    {
        return EnemyManager.Instance.GetNextEnemyPosition() - Owner.SoldierTransform.position;
    }

    public override void DoChecks()
    {
        //
    }

    private void LetSoldierShoot()
    {
        _canShoot = true;
    }
}
