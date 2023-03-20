using System.Collections;
using System.Collections.Generic;
using StateMachine.Player;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    private bool _forceWasApplied;
    private float previousFrameTime;
    private AttackAnimData _currentAttack;
    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        _currentAttack = PlayerController.Instance.data;
    }

    public override void Enter()
    {
        _stateMachine.Animator.CrossFadeInFixedTime(_currentAttack.AnimationName,_currentAttack.TransitionDuration);
    }

    public override void Tick(float DeltaTime)
    {
        Move(DeltaTime);
        float normalizeTime = GetNormalizeTime();

        if (normalizeTime >= previousFrameTime && normalizeTime < 1.0f)
        {
            if (normalizeTime >= _currentAttack.ForceTime)
            {
                TryApplyForce();
            }
        }
        
        if(!_stateMachine.InputReader.isAttacking) _stateMachine.SwitchState(_stateMachine.NormalState);
    }

    public override void Exit()
    {
    }
    
    private float GetNormalizeTime()
    {
        var currentAnimatorStateInfo = _stateMachine.Animator.GetCurrentAnimatorStateInfo(0);
        var nextAnimatorStateInfo = _stateMachine.Animator.GetNextAnimatorStateInfo(0);

        if (_stateMachine.Animator.IsInTransition(0) && nextAnimatorStateInfo.IsTag("Attack"))
        {
            return nextAnimatorStateInfo.normalizedTime;
        }
        else if (!_stateMachine.Animator.IsInTransition(0) && currentAnimatorStateInfo.IsTag("Attack"))
        {
            return currentAnimatorStateInfo.normalizedTime;
        }

        return 0f;
    }
    

    private void TryApplyForce()
    {
        if(_forceWasApplied) return;
        _stateMachine.ForceReceiver.AddForce(_stateMachine.transform.forward * _currentAttack.Force);
        _forceWasApplied = true;
    }
}
