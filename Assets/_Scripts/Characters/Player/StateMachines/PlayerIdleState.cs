using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : PlayerGroundedState
{
    float IdleStateTime;
    float currentTime;
    float currentSpeed;
    public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
<<<<<<< Updated upstream
        StartAnimation(stateMachine.Player.AnimationData.IdleParameterHash);
=======
        Debug.Log("Idle ON");
        stateMachine.MovementSpeedModifier = 0f;

        StartAnimation(stateMachine.Player.AnimationData.StandingParameterHash);

        IdleStateTime = 0.0f;
>>>>>>> Stashed changes
    }

    public override void Exit()
    {
        base.Exit();
<<<<<<< Updated upstream
        StopAnimation(stateMachine.Player.AnimationData.IdleParameterHash);
=======
        Debug.Log("Idle OFF");
        StopAnimation(stateMachine.Player.AnimationData.StandingParameterHash);
>>>>>>> Stashed changes
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.MovementInput != Vector2.zero)
        {
            OnMove();
            return;
        }
<<<<<<< Updated upstream
=======

        currentSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;

        stateMachine.Player.Animator.SetFloat("Speed", currentSpeed);

        currentTime += Time.deltaTime;
        currentTime %= 40.0f;

        IdleStateTime = currentTime;
        //IdleStateTime = Mathf.Floor(currentTime / 5.0f) * 5.0f;

        stateMachine.Player.Animator.SetFloat("Time", IdleStateTime);
        //Debug.Log("IdleStateTime: " + IdleStateTime);

        if (stateMachine.IsCrouch)
        {
            stateMachine.ChangeState(stateMachine.CrouchIdleState);
        }
>>>>>>> Stashed changes
    }
}