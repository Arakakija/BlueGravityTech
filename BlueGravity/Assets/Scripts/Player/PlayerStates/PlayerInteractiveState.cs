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
        PlayerController.Instance.CanInteract = false;
        _stateMachine.InputReader.OnCancelEvent += OnCancel;
        PlayerController.Instance.PlayerUI.ShowInteractButton(false);
        PlayerController.Instance.Interactable.Interact();
        GameUI.Instance.OnShopEvent?.Invoke();
    }

    public override void Tick(float DeltaTime)
    {
    }

    public override void Exit()
    {
        PlayerController.Instance.PlayerUI.ShowInteractButton(true);
        PlayerController.Instance.CanInteract = true;
        _stateMachine.InputReader.OnCancelEvent -= OnCancel;
    }

    private void OnCancel()
    {
        GameUI.Instance.OnCancelEvent?.Invoke();
        _stateMachine.SwitchState(_stateMachine.NormalState);
    }
}
