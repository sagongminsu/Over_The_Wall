using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRunState : PlayerGroundedState
{
    private const float StaminaDrainRate = 1f; // 초당 스태미너 감소량, 필요에 따라 조정

    public PlayerRunState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.MovementSpeedModifier = groundData.RunSpeedModifier;
        StartAnimation(stateMachine.Player.AnimationData.StandingParameterHash);
        Debug.Log("Run ON");
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.StandingParameterHash);
        Debug.Log("Run OFF");
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.IsAttacking)
        {
            OnAttack();
            return;
        }

        // 스태미너 소모 로직 추가
        if (!DrainStamina(Time.deltaTime * StaminaDrainRate))
        {
            stateMachine.ChangeState(stateMachine.WalkState);
            return;
        }

        float currentSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
        //Debug.Log(currentSpeed);
        stateMachine.Player.Animator.SetFloat("Speed", currentSpeed);
    }

    private bool DrainStamina(float amount)
    {
        PlayerConditions conditions = stateMachine.Player.GetComponent<PlayerConditions>();
        if (conditions.stamina.curValue >= amount)
        {
            conditions.UseStamina(amount);
            return true;
        }
        else
        {
            Debug.Log("Not enough stamina to run.");
            return false;
        }
    }

    protected override void OnRunCanceled(InputAction.CallbackContext context)
    {
        base.OnRunCanceled(context);
        stateMachine.ChangeState(stateMachine.WalkState);
    }
}