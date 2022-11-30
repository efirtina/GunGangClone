using UnityEngine;

public class SoldierCrouchShooting : SoldierShooting
{
    private bool _canShoot;
    public bool CanShoot
    {
        set
        {
            _canShoot = value;
            if (value)
            {
                Owner.SoldierAnimator.SetTrigger("Shoot");
            }
        }
    }
    public SoldierCrouchShooting(StateMachine<SoldierController> stateMachine) : base(stateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        CanShoot = SoldierManager.Instance.CanLastGuyShoot();
        SoldierManager.Instance.OnEverySoldierGotCover += LetSoldierShoot;
        EnemyManager.Instance.OnAllEnemiesKilled += ShowMeWhatYouGot;
        Owner.SoldierAnimator.SetTrigger("Idle");
    }

    public override void OnUpdate()
    {
        if (!_canShoot) return;
        Owner.RotateTo(CalculateFacingDirection());
        _firing.DoCountdown();
        _firing.Shoot(CalculateProjectileDirection());
    }

    public override void OnExit()
    {
        base.OnExit();
        SoldierManager.Instance.OnEverySoldierGotCover -= LetSoldierShoot;
        EnemyManager.Instance.OnAllEnemiesKilled -= ShowMeWhatYouGot;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            EnemyManager.Instance.OnAllEnemiesKilled -= ShowMeWhatYouGot;
            if (SoldierManager.Instance.GetSoldierCount() > 1)
            {
                SoldierManager.Instance.RemoveSoldierFromList(Owner);
                GameObject.Destroy(Owner.gameObject);
            }
            else
            {
                GameManager.Instance.OnGameOver?.Invoke();
                GameObject.Destroy(Owner.gameObject);
            }
        }
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
        Owner.SoldierAnimator.SetTrigger("Shoot");
    }

    private void ShowMeWhatYouGot()
    {
        Owner.ChangeState(Owner._danceState);
    }
}
