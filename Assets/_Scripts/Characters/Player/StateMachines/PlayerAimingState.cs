using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimingState : PlayerGroundedState
{
    public PlayerAimingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0f;
        base.Enter();
        Debug.Log("ON");
        StartAnimation(stateMachine.Player.AnimationData.AimingParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("OFF");
        StopAnimation(stateMachine.Player.AnimationData.AimingParameterHash);
    }
}
