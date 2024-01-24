using UnityEngine;

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
        Debug.Log("coruch ON");

        StartAnimation(stateMachine.Player.AnimationData.CrouchParameterHash);

        currentSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier * 0.5f;

        stateMachine.Player.Animator.SetFloat("Speed", currentSpeed);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("coruch OFF");

        StopAnimation(stateMachine.Player.AnimationData.CrouchParameterHash);

        //stateMachine.Player.Controller.height = 1.77f;
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
    }
}