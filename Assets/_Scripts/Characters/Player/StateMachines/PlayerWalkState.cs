using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerWalkState : PlayerGroundedState
{


    public PlayerWalkState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = groundData.WalkSpeedModifier;
        base.Enter();

        StartAnimation(stateMachine.Player.AnimationData.StandingParameterHash);

        //StartAnimation(stateMachine.Player.AnimationData.WalkParameterHash);
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(stateMachine.Player.AnimationData.StandingParameterHash);

        //StopAnimation(stateMachine.Player.AnimationData.WalkParameterHash);
    }
    public override void Update()
    {
        base.Update();

        float currentSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
        stateMachine.Player.PlayerAnimator.SetFloat("Speed", currentSpeed);
    }

    protected override void OnRunStarted(InputAction.CallbackContext context)
    {
        base.OnRunStarted(context);
        stateMachine.ChangeState(stateMachine.RunState);
    }

    protected override void OnAimingPerformed(InputAction.CallbackContext context)
    {
        base.OnRunStarted(context);
        stateMachine.ChangeState(stateMachine.AimingWalkState);
    }
}
