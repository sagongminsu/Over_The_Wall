using UnityEngine;

public class PlayerStandingState : PlayerGroundedState
{
    public PlayerStandingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        StartAnimation(stateMachine.Player.AnimationData.StandingParameterHash);
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(stateMachine.Player.AnimationData.StandingParameterHash);
    }

    public override void Update()
    {
        base.Update();

        stateMachine.Player.Animator.SetFloat("Velocity.x", stateMachine.MovementInput.y);
        stateMachine.Player.Animator.SetFloat("Velocity.y", stateMachine.MovementInput.x);
    }
}
