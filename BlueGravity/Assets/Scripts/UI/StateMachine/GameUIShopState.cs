using System.Collections;
using System.Collections.Generic;
using StateMachine.UI;
using UnityEngine;

public class GameUIShopState : GameUIBaseState
{
    public GameUIShopState(GameUIStateMachine stateMachine) : base(stateMachine)
    {
        
    }

    public override void Enter()
    {
        GameUI.Instance.OnCancelEvent += Cancel;
        GameUI.Instance.ShowTradeUI(true);
        
        if(!GameUI.Instance.IsInventoryOpen)
            GameUI.Instance.ShowPlayerInventoryUI(true);
    }

    public override void Tick(float DeltaTime)
    {
       
    }

    public override void Exit()
    {
        GameUI.Instance.ShowTradeUI(false);
        GameUI.Instance.ShowPlayerInventoryUI(false);
    }

    void Cancel()
    {
        _stateMachine.SwitchState(new GameUINormalState(_stateMachine));
    }
}
