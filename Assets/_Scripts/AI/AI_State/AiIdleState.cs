using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiIdleState : AiBaseState
{
    public AiIdleState(AiStateMachine aiStateMachine) : base(aiStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0f;

        base.Enter();
        StartAnimation(stateMachine.Ai.AnimationData.GroundParameterHash);
        
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Ai.AnimationData.GroundParameterHash);
        
    }

    public override void Update()
    {
        if (IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.ChasingState);
            return;
        }
    }

}
