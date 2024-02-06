using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiChasingState : AiBaseState
{   

    public AiChasingState(AiStateMachine aiStateMachine) : base(aiStateMachine)
    {
    }
    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 1;
        base.Enter();
        StartAnimation(stateMachine.Ai.AnimationData.GroundParameterHash);
        StartAnimation(stateMachine.Ai.AnimationData.RunParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Ai.AnimationData.GroundParameterHash);
        StopAnimation(stateMachine.Ai.AnimationData.RunParameterHash);

    }

    public override void Update()
    {
        base.Update();

        if (!IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.IdleingState);
            return;
        }
        else if (IsInAttackRange())
        {
            stateMachine.ChangeState(stateMachine.AttackState);
            return;
        }
    }

    private bool IsInAttackRange()
    {
        // if (stateMachine.Target.IsDead) { return false; }

        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Ai.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.Ai.Data.AttackRange * stateMachine.Ai.Data.AttackRange;
    }
}
