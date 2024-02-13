using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCrouchIdleState : PlayerGroundedState
{
    float currentSpeed;

    public PlayerCrouchIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0f;
        base.Enter();

        StartAnimation(stateMachine.Player.AnimationData.CrouchParameterHash);
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(stateMachine.Player.AnimationData.CrouchParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.IsCrouch)
        {
            if (stateMachine.MovementInput != Vector2.zero)
            {
                OnMove();
                return;
            }
        }
        if (!stateMachine.IsCrouch)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}