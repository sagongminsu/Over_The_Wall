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

        // ���� ���¿� ������ �� ������ �浹 ó�� ����Ʈ�� �ʱ�ȭ
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
        // ���� ���¸� ���� �� IsAttacked�� false�� �����Ͽ�, ���� ������ ���ο� ���ظ� �޾��� ���� �߻��ϵ��� ��
        stateMachine.IsAttacked = false;
    }


    public override void Update()
    {
        base.Update();

        ForceMove();
        float distanceToPlayer = Vector3.Distance(stateMachine.Ai.transform.position, stateMachine.Target.position);
        //�����ؼ� ����
        float normalizedTime = GetNormalizedTime(stateMachine.Ai.Animator, "Attack");

        if (normalizedTime < 1f)
        {
            stateMachine.Ai.Agent.isStopped = true;
            if (normalizedTime >= stateMachine.Ai.Data.ForceTransitionTime && !alreadyAppliedForce)
            {
                TryApplyForce();
            }

            //������
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
            //�޼�
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
            // ���� �ִϸ��̼��� ������ ���, �̵� �簳
            stateMachine.Ai.Agent.isStopped = false;

            // �÷��̾ ���� �ٽ� �̵� ����
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
