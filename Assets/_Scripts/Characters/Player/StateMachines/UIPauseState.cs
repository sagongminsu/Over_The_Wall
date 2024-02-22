using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPauseState : PlayerBaseState
{
    public UIPauseState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Time.timeScale = 0.0f;
        //UIÄÑÁü
    }

    public override void Exit()
    {
        base.Exit();
        Time.timeScale = 1.0f;
        //UI²¨Áü
    }
}
