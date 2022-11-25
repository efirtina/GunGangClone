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
        _firing.SetShootTimer(1f);
    }
    
}