using UnityEngine.InputSystem;

public class PlayerWalkState : PlayerGroundedState
{
    float currentSpeed;

    public PlayerWalkState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = groundData.WalkSpeedModifier;
        base.Enter();
        Debug.Log("Walk ON");

        StartAnimation(stateMachine.Player.AnimationData.StandingParameterHash);

        currentSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;

        //StartAnimation(stateMachine.Player.AnimationData.WalkParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Walk OFF");

        StopAnimation(stateMachine.Player.AnimationData.StandingParameterHash);

        //StopAnimation(stateMachine.Player.AnimationData.WalkParameterHash);
    }

<<<<<<< Updated upstream
=======
    public override void Update()
    {
        base.Update();

        Debug.Log(currentSpeed);
        stateMachine.Player.Animator.SetFloat("Speed", currentSpeed);

        if (stateMachine.IsCrouch)
        {
            stateMachine.ChangeState(stateMachine.CrouchWalkState);
        }
    }

>>>>>>> Stashed changes
    protected override void OnRunStarted(InputAction.CallbackContext context)
    {
        base.OnRunStarted(context);
        stateMachine.ChangeState(stateMachine.RunState);
    }
}