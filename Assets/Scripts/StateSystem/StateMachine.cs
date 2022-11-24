using UnityEngine;

public class StateMachine<T>
{
    public State<T> CurrentState { get; private set; }
    public T Owner { get; private set; }

    public void InitializeStateMachine(State<T> initialState, T Owner)
    {
        this.Owner = Owner;
        CurrentState = initialState;
        CurrentState.OnEnter();
    }

    public void ChangeState(State<T> newState)
    {
        CurrentState.OnExit(); 
        CurrentState = newState;
        CurrentState.OnEnter();
    }
}
