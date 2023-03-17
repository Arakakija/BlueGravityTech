using System.Collections;
using System.Collections.Generic;
using StateMachine.Player;
using UnityEngine;

public abstract class PlayerBaseState : IState
{
    protected PlayerStateMachine _stateMachine;

    protected PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this._stateMachine = stateMachine;
    }

    public abstract void Enter();
    public abstract void Tick(float DeltaTime);
    public abstract void Exit();

    protected void Move(Vector2 motion, float DeltaTime)
    {
        _stateMachine.Move((motion + _stateMachine.ForceReceiver.Movement)* DeltaTime);
    }
    
    protected void Move(float DeltaTime)
    {
        _stateMachine.Move(_stateMachine.ForceReceiver.Movement * DeltaTime);
    }

    protected void StopMove()
    {
        _stateMachine.Move(Vector2.zero);
    }
    
}
