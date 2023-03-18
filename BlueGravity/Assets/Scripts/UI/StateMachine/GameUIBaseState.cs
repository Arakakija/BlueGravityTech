using System.Collections;
using System.Collections.Generic;
using StateMachine.UI;
using UnityEngine;

public abstract class GameUIBaseState : IState
{
    protected GameUIStateMachine _stateMachine;

    protected GameUIBaseState(GameUIStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public abstract void Enter();
    
    public abstract void Tick(float DeltaTime);
    public abstract void Exit();

}
