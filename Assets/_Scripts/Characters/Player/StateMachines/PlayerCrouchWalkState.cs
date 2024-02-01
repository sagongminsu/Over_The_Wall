using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCrouchWalkState : PlayerGroundedState
{
    public PlayerCrouchWalkState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = groundData.WalkSpeedModifier;
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

        float currentSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier * 0.5f;

        Debug.Log(currentSpeed);
        stateMachine.Player.Animator.SetFloat("Speed", currentSpeed);

        if (!stateMachine.IsCrouch)
        {
            stateMachine.ChangeState(stateMachine.WalkState);
        }
    }
}