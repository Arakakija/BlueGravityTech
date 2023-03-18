using System.Collections;
using System.Collections.Generic;
using StateMachine.UI;
using UnityEngine;

public class GameUINormalState : GameUIBaseState
{

    public GameUINormalState(GameUIStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        GameUI.Instance.OnShopEvent += OnInteract;
    }

    public override void Tick(float DeltaTime)
    {
        
    }

    public override void Exit()
    {
        
    }

    void OnInteract() 
    {
        _stateMachine.SwitchState(new GameUIShopState(_stateMachine));
    }
}
