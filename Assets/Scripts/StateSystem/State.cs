using UnityEngine;

public abstract class State<T>
{
    public State(StateMachine<T> stateMachine)
    {
        StateMachine = stateMachine;
    }

    public StateMachine<T> StateMachine { get; private set; }
    public T Owner
    {
        get
        {
            return StateMachine.Owner;
        }
    }

    public virtual void OnEnter()
    {
        
    }

    public virtual void OnUpdate()
    {
        DoChecks();
    }

    public virtual void OnFixedUpdate()
    {

    }

    public virtual void OnExit()
    {

    }

    public virtual void DoChecks()
    {

    }
}
