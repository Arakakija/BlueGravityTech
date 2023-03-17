using System.Collections;
using System.Collections.Generic;
using StateMachine.Player;
using UnityEngine;

public class PlayerInteractiveState : PlayerBaseState
{
    public PlayerInteractiveState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        _stateMachine.PlayerController.CanInteract = false;
        _stateMachine.InputReader.OnCancelEvent += OnCancel;
        _stateMachine.PlayerController.PlayerUI.ShowInteractButton(false);
        
        GameUI.Instance.ShowTradeUI(true);
        
        if(!GameUI.Instance.IsInventoryOpen)
            GameUI.Instance.ShowPlayerInventoryUI(true);
     
    }

    public override void Tick(float DeltaTime)
    {
    }

    public override void Exit()
    {
        _stateMachine.PlayerController.PlayerUI.ShowInteractButton(true);
        _stateMachine.PlayerController.CanInteract = true;
    }

    private void OnCancel()
    {
        GameUI.Instance.ShowTradeUI(false);
        GameUI.Instance.ShowPlayerInventoryUI(false);
        _stateMachine.SwitchState(new PlayerNormalState(_stateMachine));
    }
}
