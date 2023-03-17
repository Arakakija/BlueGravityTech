using System.Collections;
using System.Collections.Generic;
using StateMachine.Player;
using UnityEngine;

public class PlayerNormalState : PlayerBaseState
{
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Mirror = Animator.StringToHash("Mirror");
    private const float AnimatorDampTime = 0.1f;
    private const float FixedTransitionDuration = 0.1f;
    public PlayerNormalState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        _stateMachine.InputReader.OnInteractEvent += OnInteract;
    }

    public override void Tick(float DeltaTime)
    {
        Vector2 movement = CalculateMovement();
        Move(movement, DeltaTime);

        if (_stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            _stateMachine.Animator.SetFloat(Speed,0,AnimatorDampTime,FixedTransitionDuration);
            return;
        }
        
        if(_stateMachine.InputReader.MovementValue.x != 0)
            TryMirrorPlayer();
        
        _stateMachine.Animator.SetFloat(Speed,1,AnimatorDampTime,FixedTransitionDuration);
        
    }

    public override void Exit()
    {
        
    }

    void TryMirrorPlayer()
    {
        AnimatorStateInfo stateInfo = _stateMachine.Animator.GetCurrentAnimatorStateInfo(0);
        bool mirror = stateInfo.IsName("Normal State") && _stateMachine.InputReader.MovementValue.x > 0.5f;
       _stateMachine.Animator.transform.localScale = new Vector3(mirror ? -1 : 1, 1, 1);
    }

    Vector2 CalculateMovement()
    {
        return _stateMachine.InputReader.MovementValue;
    }
    
    private void OnInteract()
    {
        if(_stateMachine.PlayerController.CanInteract)
            Debug.Log("OPEN SHOP");
    }
}
