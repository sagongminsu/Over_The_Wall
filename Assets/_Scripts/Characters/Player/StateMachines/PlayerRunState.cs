using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRunState : PlayerGroundedState
{
    private const float StaminaDrainRate = 1f; // �ʴ� ���¹̳� ���ҷ�, �ʿ信 ���� ����

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

        // ���¹̳� �Ҹ� ���� �߰�
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