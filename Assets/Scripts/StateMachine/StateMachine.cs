using UnityEngine;

public class StateMachine
{
    private bool canChangeState = true;
    public EntityState currentState { get; private set; }

    public void Initialize(EntityState startState)
    {
        currentState = startState;
        currentState.Enter();
    }

    public void ChangeState(EntityState newState)
    {
        if (!canChangeState)
            return;

        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void UpdateActiveState()
    {
        currentState.Update();
    }

    public void CanNotChangeState() => canChangeState = false;
}
