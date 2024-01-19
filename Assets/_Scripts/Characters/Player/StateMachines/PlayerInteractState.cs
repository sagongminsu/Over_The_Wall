using TMPro;
using UnityEngine;

public class PlayerInteractState : PlayerGroundedState
{
    private InteractionManager interactionManager;

    public PlayerInteractState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
        interactionManager = InteractionManager.Instance;
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0;

        if (interactionManager.CurrentInteractGameObject != null && interactionManager.CurrentInteraction != null)
        {
            interactionManager.CurrentInteraction.OnInteract();
        }
        else
        {
            Debug.LogError("Interaction failed. Check if the object implements IInteraction interface.");
        }

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
    }
}
