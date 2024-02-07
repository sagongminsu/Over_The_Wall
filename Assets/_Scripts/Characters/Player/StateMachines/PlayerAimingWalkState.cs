using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAimingWalkState : PlayerGroundedState
{
    public PlayerAimingWalkState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = groundData.WalkSpeedModifier;
        base.Enter();

        StartAnimation(stateMachine.Player.AnimationData.AimingParameterHash);
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(stateMachine.Player.AnimationData.AimingParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.IsAttacking)
        {
            OnAttack();
            return;
        }

        float currentSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;

        stateMachine.Player.PlayerAnimator.SetFloat("Speed", currentSpeed);
    }

    protected override void OnAimingCanceled(InputAction.CallbackContext context)
    {
        base.OnAimingCanceled(context);
        stateMachine.ChangeState(stateMachine.WalkState);
    }
}
