using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackState : AiBaseState
{
    private bool alreadyAppliedForce;
    private bool RigntalreadyAppliedDealing;
    private bool LeftalreadyAppliedDealing;

    public AiAttackState(AiStateMachine aiStateMachine) : base(aiStateMachine)
    {
    }

    public override void Enter()
    {
        alreadyAppliedForce = false;
        RigntalreadyAppliedDealing = false;
        LeftalreadyAppliedDealing = false;

        stateMachine.MovementSpeedModifier = 0;
        base.Enter();
        StartAnimation(stateMachine.Ai.AnimationData.AttackParameterHash);

        // 공격 상태에 진입할 때 무기의 충돌 처리 리스트를 초기화
        if (stateMachine.Ai.RightHandWeapon != null)
        {
            stateMachine.Ai.RightHandWeapon.ResetCollisions();
        }

        if (stateMachine.Ai.LeftHandWeapon != null)
        {
            stateMachine.Ai.LeftHandWeapon.ResetCollisions();
        }
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Ai.AnimationData.AttackParameterHash);
        // 공격 상태를 나갈 때 IsAttacked를 false로 설정하여, 다음 공격은 새로운 피해를 받았을 때만 발생하도록 함
        stateMachine.IsAttacked = false;
    }


    public override void Update()
    {
        base.Update();

        ForceMove();
        float distanceToPlayer = Vector3.Distance(stateMachine.Ai.transform.position, stateMachine.Target.position);
        //지속해서 추적
        float normalizedTime = GetNormalizedTime(stateMachine.Ai.Animator, "Attack");

        if (normalizedTime < 1f)
        {
            stateMachine.Ai.Agent.isStopped = true;
            if (normalizedTime >= stateMachine.Ai.Data.ForceTransitionTime && !alreadyAppliedForce)
            {
                TryApplyForce();
            }

            //오른손
            if (!RigntalreadyAppliedDealing && normalizedTime >= stateMachine.Ai.Data.Dealing_Start_TransitionTime)
            {
                stateMachine.Ai.RightHandWeapon.SetAttack(stateMachine.Ai.Data.Damage, stateMachine.Ai.Data.Force);
                stateMachine.Ai.RightHandWeapon.gameObject.SetActive(true);
                RigntalreadyAppliedDealing = true;
            }

            if (RigntalreadyAppliedDealing && normalizedTime >= stateMachine.Ai.Data.Dealing_End_TransitionTime)
            {
                stateMachine.Ai.RightHandWeapon.gameObject.SetActive(false);
            }
            //왼손
            if (!LeftalreadyAppliedDealing && normalizedTime >= stateMachine.Ai.Data.Dealing_Start_TransitionTime)
            {
                stateMachine.Ai.LeftHandWeapon.SetAttack(stateMachine.Ai.Data.Damage, stateMachine.Ai.Data.Force);
                stateMachine.Ai.LeftHandWeapon.gameObject.SetActive(true);
                LeftalreadyAppliedDealing = true;
            }

            if (LeftalreadyAppliedDealing && normalizedTime >= stateMachine.Ai.Data.Dealing_End_TransitionTime)
            {
                stateMachine.Ai.LeftHandWeapon.gameObject.SetActive(false);
            }
        }


        else
        {
            // 공격 애니메이션이 끝났을 경우, 이동 재개
            stateMachine.Ai.Agent.isStopped = false;

            // 플레이어를 향해 다시 이동 시작
            if (distanceToPlayer > stateMachine.Ai.Agent.stoppingDistance)
            {
                stateMachine.Ai.Agent.SetDestination(stateMachine.Target.position);
            }
        }
    }

    private void TryApplyForce()
    {
        if (alreadyAppliedForce) return;
        alreadyAppliedForce = true;

        stateMachine.Ai.ForceReceiver.Reset();

        stateMachine.Ai.ForceReceiver.AddForce(stateMachine.Ai.transform.forward * stateMachine.Ai.Data.Force);

    }

}
