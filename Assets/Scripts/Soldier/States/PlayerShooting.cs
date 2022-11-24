using UnityEngine;

public class PlayerShooting : SoldierShooting
{
    private PlayerController _player;
    public PlayerShooting(StateMachine<SoldierController> stateMachine) : base(stateMachine)
    {
    }
    public override void OnEnter()
    {
        base.OnEnter();
        if(_player == null)
        {
            _player = Owner.GetComponent<PlayerController>();
        }
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        _player._playerMovement.Move();
    }
}
