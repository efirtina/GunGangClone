using UnityEngine;

public class SoldierRunning : State<SoldierController>
{
    public SoldierRunning(StateMachine<SoldierController> stateMachine) : base(stateMachine)
    {
    }
}
