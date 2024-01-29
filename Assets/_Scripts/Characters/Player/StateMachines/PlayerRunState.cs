using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRunState : PlayerGroundedState
{   

    public PlayerRunState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = groundData.RunSpeedModifier;
        base.Enter();

        Debug.Log("Run ON");

        StartAnimation(stateMachine.Player.AnimationData.StandingParameterHash);
        //StartAnimation(stateMachine.Player.AnimationData.RunParameterHash);
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(stateMachine.Player.AnimationData.StandingParameterHash);
        //StopAnimation(stateMachine.Player.AnimationData.RunParameterHash);
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

        Debug.Log(currentSpeed);
        stateMachine.Player.Animator.SetFloat("Speed", currentSpeed);
    }

    protected override void OnRunCanceled(InputAction.CallbackContext context)
    {
        base.OnRunCanceled(context);
        Debug.Log("Run OFF");
        stateMachine.ChangeState(stateMachine.WalkState);
    }
}