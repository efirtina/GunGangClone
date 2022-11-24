using System.Threading;
using UnityEngine;

public class SoldierShooting : State<SoldierController>
{
    protected float _shootTimer;
    protected float Cooldown
    { 
        get
        {
            return 1 / Owner._firingRate;
        } 
    }
    public SoldierShooting(StateMachine<SoldierController> stateMachine) : base(stateMachine)
    {
        
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        _shootTimer -= Time.deltaTime;
        Shoot();
    }
    public override void OnExit()
    {
        base.OnExit();
        _shootTimer = 0f;
    }
    public override void DoChecks()
    {
        base.DoChecks();
    }
    protected void Shoot()
    {
        if(_shootTimer <= 0)
        {
            ProjectileManager.Instance.PullProjectile(Owner.SoldierTransform.position);
            _shootTimer = Cooldown;
        }
    }
}