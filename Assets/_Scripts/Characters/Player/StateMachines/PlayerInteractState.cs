using UnityEngine;

public class PlayerInteractState : PlayerGroundedState
{
    public PlayerInteractState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0;

        Debug.Log("ON");

        base.Enter();
        //enter 애니메이션 넣을거면 넣으면됨
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
