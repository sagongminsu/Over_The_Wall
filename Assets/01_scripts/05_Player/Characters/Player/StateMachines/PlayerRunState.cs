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

        // Run 상태에서 WalkSound 재생 (Pitch를 빠르게 설정)
        AudioManager.Instance.PlayWalkSound(1.7f); // 예시로 Pitch를 1.5로 설정
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.StandingParameterHash);

        // Run 상태에서 WalkSound 중지
        AudioManager.Instance.StopWalkSound();
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
        stateMachine.Player.PlayerAnimator.SetFloat("Speed", currentSpeed);
    }

    private bool DrainStamina(float amount)
    {
        PlayerConditions conditions = stateMachine.Player.GetComponent<PlayerConditions>();
        if (conditions.playerSO.Stamina.curValue >= amount)
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