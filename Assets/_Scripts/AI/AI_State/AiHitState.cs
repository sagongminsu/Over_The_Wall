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
        // �ǰ� �ִϸ��̼� ���
        stateMachine.Ai.Animator.SetTrigger(HitAnimHash);
        // �߰�������, �ǰ� ���¿� �ʿ��� �ʱ�ȭ�� ������ ���⼭ ����
    }

    public override void Update()
    {
        base.Update();


            stateMachine.ChangeState(stateMachine.IdleingState); // ���� ��ȯ ����
        
    }
}
