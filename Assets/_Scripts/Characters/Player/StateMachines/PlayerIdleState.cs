using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateMachine.MovementSpeedModifier = 0f;
        Debug.Log("¿‘¿Â");
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

        if (stateMachine.MovementInput != Vector2.zero)
        {
            OnMove();
            return;
        }

        if (stateMachine.IsAttacking)
        {
            if(stateMachine.Player.Inven.CheckActive() == false)
            OnAttack();
            return;
        }

        float currentSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;

        stateMachine.Player.PlayerAnimator.SetFloat("Speed", currentSpeed);


        if(stateMachine.IsAiming)
        {
            stateMachine.ChangeState(stateMachine.AimingIdleState);
        }
    }
}