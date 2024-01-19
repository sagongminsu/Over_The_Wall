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
        //enter �ִϸ��̼� �����Ÿ� �������
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
    }
}
