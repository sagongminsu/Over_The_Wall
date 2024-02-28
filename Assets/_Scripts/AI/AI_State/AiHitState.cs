using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;

public class AiHitState : AiBaseState
{
    private static readonly int HitAnimHash = Animator.StringToHash("Hit");

    public AiHitState(AiStateMachine aiStateMachine) : base(aiStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        // 피격 애니메이션 재생
        stateMachine.Ai.Animator.SetTrigger(HitAnimHash);
        // 추가적으로, 피격 상태에 필요한 초기화나 설정을 여기서 수행
    }

    public override void Update()
    {
        base.Update();


            stateMachine.ChangeState(stateMachine.IdleingState); // 상태 전환 예시
        
    }
}
