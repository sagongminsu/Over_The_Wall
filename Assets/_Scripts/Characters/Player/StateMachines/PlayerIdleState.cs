using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0f;
        base.Enter();
        float currentSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;

        Debug.Log(currentSpeed);
        stateMachine.Player.Animator.SetFloat("Speed", currentSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.MovementInput != Vector2.zero)
        {
            OnMove();
            return;
        }

        
    }
}