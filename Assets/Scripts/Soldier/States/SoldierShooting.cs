using UnityEngine;

public class SoldierShooting : State<SoldierController>
{
    public SoldierShooting(StateMachine<SoldierController> stateMachine) : base(stateMachine)
    {
    }
}