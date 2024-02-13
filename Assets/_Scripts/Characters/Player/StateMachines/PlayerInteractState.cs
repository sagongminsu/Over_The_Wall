using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractState : PlayerGroundedState
{
    private InteractionManager interactionManager;
    private bool hasInteracted = false;
    private float interactCooldown = 0.2f;
    private float interactTimer = 0f;

    public PlayerInteractState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
        interactionManager = InteractionManager.Instance;
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0;

        if (!hasInteracted && interactionManager.CurrentInteractGameObject != null && interactionManager.CurrentInteraction != null)
        {
            interactionManager.CurrentInteraction.OnInteract();
            hasInteracted = true;
            interactTimer = interactCooldown; // ��ȭ ���� �� Ÿ�̸� �ʱ�ȭ
        }
        else
        {
            //Debug.LogError("Interaction failed. Check if the object implements IInteraction interface.");
        }
        //���⿡�� �ؽ�Ʈ�� ���� �������� �µǾ����

        base.Enter();
    }

    public override void Exit()
    {
        Debug.Log("OFF");

        base.Exit();
        //exit �ִϸ��̼� �����Ÿ� �������
    }

    public override void Update()
    {
        base.Update();

        if (hasInteracted)
        {
            interactTimer -= Time.deltaTime;
            if (interactTimer <= 0)
            {
                hasInteracted = false;
            }
        }
    }

    protected override void OnInteractionCanceled(InputAction.CallbackContext context)
    {
        base.OnInteractionCanceled(context);
        stateMachine.ChangeState(stateMachine.IdleState);
    }
}
