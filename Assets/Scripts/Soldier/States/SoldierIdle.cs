using UnityEngine;

public class SoldierIdle : State<SoldierController>
{
    public SoldierIdle(StateMachine<SoldierController> stateMachine) : base(stateMachine)
    {
    }
}
