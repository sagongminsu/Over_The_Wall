using System.Collections;
using TMPro;
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
        //여기에서 텍스트를 끄고 게이지가 온되어야함

        base.Enter();
    }

    public override void Exit()
    {

        base.Exit();
        //exit 애니메이션 넣을거면 넣으면됨
    }

    public override void Update()
    {
        base.Update();

        //게이지를 여기서 관리하면?
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
