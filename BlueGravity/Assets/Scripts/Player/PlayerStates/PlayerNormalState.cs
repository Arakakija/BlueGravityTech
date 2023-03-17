using System.Collections;
using System.Collections.Generic;
using StateMachine.Player;
using UnityEngine;

public class PlayerNormalState : PlayerBaseState
{
    public PlayerNormalState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        
    }

    public override void Tick(float DeltaTime)
    {
        Vector2 movement = CalculateMovement();
        Move(movement, DeltaTime);
    }

    public override void Exit()
    {
        
    }

    Vector2 CalculateMovement()
    {
        return _stateMachine.InputReader.MovementValue;
    }
}
