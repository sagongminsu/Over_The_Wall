using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractState : PlayerGroundedState
{
    private InteractionManager interactionManager;

    public PlayerInteractState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
        interactionManager = InteractionManager.Instance;
    }

    public override void Enter()
    {

        if (interactionManager.CurrentInteractGameObject != null && interactionManager.CurrentInteraction != null)
        {
            interactionManager.CurrentInteraction.OnInteract();
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

        base.Exit();
        //exit �ִϸ��̼� �����Ÿ� �������
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void OnInteractionCanceled(InputAction.CallbackContext context)
    {
        base.OnInteractionCanceled(context);

        if (stateMachine.IsCrouch)
            stateMachine.ChangeState(stateMachine.CrouchIdleState);
        else if (stateMachine.MovementSpeedModifier == groundData.RunSpeedModifier)
            stateMachine.ChangeState(stateMachine.RunState);
        else
            stateMachine.ChangeState(stateMachine.IdleState);
    }

}
