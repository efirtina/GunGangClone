using UnityEngine;

public class PlayerShooting : SoldierShooting
{
    private PlayerController _player;

    public PlayerShooting(StateMachine<SoldierController> stateMachine) : base(stateMachine)
    {
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Obstacle")) return;
        var victim = SoldierManager.Instance.GetVictimSoldierToKill();
        if(victim == null)
        {
            GameManager.Instance.OnGameOver?.Invoke();
            GameObject.Destroy(Owner);
            return;
        }
        _player._playerMovement.SetMovementVector(victim.transform.position);
        SoldierManager.Instance.RemoveSoldierFromList(victim);
        GameObject.Destroy(victim.gameObject);
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
        _player._playerMovement.GetInputs();
        _player._playerMovement.Move();
    }
}