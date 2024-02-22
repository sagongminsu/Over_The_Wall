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
        // �ǰ� �ִϸ��̼� ��� �ð��̳� �ٸ� ������ ������� ���� ���·��� ��ȯ�� ��ȹ
        // ���� ���, �ִϸ��̼��� ������ ���� ���·� ��ȯ



    }
    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Ai.AnimationData.HitParameterHash);


    }

    public override void Update()
    {
        base.Update();
        // �ǰ� ���¿��� ������ ������ �߰�
        //�ִϸ��̼��� ���� ������ üũ�ϰ� �Ϸ�Ǹ� ���� ���·� ��ȯ
    }
}
