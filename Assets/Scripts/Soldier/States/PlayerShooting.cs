using UnityEngine;

public class PlayerShooting : SoldierShooting
{
    public PlayerShooting(StateMachine<SoldierController> stateMachine) : base(stateMachine)
    {
    }
}
