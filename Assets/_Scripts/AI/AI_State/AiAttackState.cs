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

        float normalizedTime = GetNormalizedTime(stateMachine.Ai.Animator, "Attack");
        if (normalizedTime < 1f)
        {
            if (normalizedTime >= stateMachine.Ai.Data.ForceTransitionTime)
                TryApplyForce();
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

    }

    private void TryApplyForce()
    {
        if (alreadyAppliedForce) return;
        alreadyAppliedForce = true;

        stateMachine.Ai.ForceReceiver.Reset();

        stateMachine.Ai.ForceReceiver.AddForce(stateMachine.Ai.transform.forward * stateMachine.Ai.Data.Force);

    }
}
