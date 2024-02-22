using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHitState : AiBaseState
{
    private static readonly int hitTrigger = Animator.StringToHash("Hit");

    public AiHitState(AiStateMachine aiStateMachine) : base(aiStateMachine) { }

    public override void Enter()
    {

        stateMachine.MovementSpeedModifier = 0f;

        base.Enter();
        stateMachine.Ai.Animator.SetTrigger(stateMachine.Ai.AnimationData.HitParameterHash);
        // 피격 애니메이션 재생 시간이나 다른 조건을 기반으로 다음 상태로의 전환을 계획
        // 예를 들어, 애니메이션이 끝나면 다음 상태로 전환



    }
    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Ai.AnimationData.HitParameterHash);


    }

    public override void Update()
    {
        base.Update();
        // 피격 상태에서 수행할 로직을 추가
        //애니메이션의 진행 정도를 체크하고 완료되면 다음 상태로 전환
    }
}
