using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundedState : PlayerBaseState
{
    private bool isWalking = false;

    public PlayerGroundedState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.GroundParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.GroundParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.IsAttacking)
        {
            OnAttack();
            return;
        }

        //if (stateMachine.IsInteracting)
        //{
        //    OnInteraction();
        //    return;
        //}
        if (stateMachine.IsCrouch)
        {
            OnCrouch();
            return;
        }

        // 걷기 시작 확인
        if (stateMachine.MovementInput != Vector2.zero && !isWalking)
        {
            AudioManager.Instance.PlayWalkSound(1.0f);
            isWalking = true;
        }
        // 걷기 종료 확인
        else if (stateMachine.MovementInput == Vector2.zero && isWalking)
        {
            AudioManager.Instance.StopWalkSound();
            isWalking = false;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (!stateMachine.Player.Controller.isGrounded
            && stateMachine.Player.Controller.velocity.y < Physics.gravity.y * Time.fixedDeltaTime)
        {
            stateMachine.ChangeState(stateMachine.FallState);
            return;
        }
    }

    protected override void OnMovementCanceled(InputAction.CallbackContext context)
    {
        if (stateMachine.MovementInput == Vector2.zero)
        {
            return;
        }
        stateMachine.ChangeState(stateMachine.IdleState);
        base.OnMovementCanceled(context);
    }

    protected virtual void OnMove()
    {
        if (stateMachine.IsCrouch)
            stateMachine.ChangeState(stateMachine.CrouchWalkState);
        else if (stateMachine.IsAiming)
            stateMachine.ChangeState(stateMachine.AimingWalkState);
        else
            stateMachine.ChangeState(stateMachine.WalkState);
    }

    protected override void OnJumpStarted(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(stateMachine.JumpState);
    }

    protected override void OnRunCanceled(InputAction.CallbackContext context)
    {
        base.OnRunCanceled(context);
        stateMachine.ChangeState(stateMachine.IdleState);
    }
    protected override void OnInteractionStarted(InputAction.CallbackContext context)
    {
        base.OnInteractionStarted(context);
        stateMachine.ChangeState(stateMachine.InteractState);
    }

    protected virtual void OnAttack()
    {
        stateMachine.ChangeState(stateMachine.ComboAttackState);
    }

    protected virtual void OnCrouch()
    {
        stateMachine.ChangeState(stateMachine.CrouchIdleState);

        if (stateMachine.MovementInput != Vector2.zero)
            stateMachine.ChangeState(stateMachine.CrouchWalkState);
    }

    //protected virtual void OnInteraction()
    //{
    //    stateMachine.ChangeState(stateMachine.InteractState);
    //}

    protected virtual void OnAim()
    {
        stateMachine.ChangeState(stateMachine.AimingIdleState);
    }
}
