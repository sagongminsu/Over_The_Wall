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
            interactTimer = interactCooldown; // 대화 시작 후 타이머 초기화
        }
        else
        {
            //Debug.LogError("Interaction failed. Check if the object implements IInteraction interface.");
        }
        //여기에서 텍스트를 끄고 게이지가 온되어야함

        base.Enter();
    }

    public override void Exit()
    {
        Debug.Log("OFF");

        base.Exit();
        //exit 애니메이션 넣을거면 넣으면됨
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
