using System;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerComboAttackState : PlayerAttackState
{
    private bool alreadyAppliedForce;
    private bool alreadyApplyCombo;

    AttackInfoData attackInfoData;

    public PlayerComboAttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.ComboAttackParameterHash);

        alreadyApplyCombo = false;
        alreadyAppliedForce = false;

        int comboIndex = stateMachine.ComboIndex;
        attackInfoData = stateMachine.Player.Data.AttackData.GetAttackInfo(comboIndex);
        stateMachine.Player.PlayerAnimator.SetInteger("Combo", comboIndex);
        stateMachine.Player.ArmAnimator.SetInteger("Combo", comboIndex);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.ComboAttackParameterHash);

        if (!alreadyApplyCombo)
            stateMachine.ComboIndex = 0;
    }

    private void TryComboAttack()
    {
        if (alreadyApplyCombo) return;

        if (attackInfoData.ComboStateIndex == -1) return;

        if (!stateMachine.IsAttacking) return;

        alreadyApplyCombo = true;
    }

    private void TryApplyForce()
    {
        if (alreadyAppliedForce) return;
        alreadyAppliedForce = true;

        stateMachine.Player.ForceReceiver.Reset();

        stateMachine.Player.ForceReceiver.AddForce(stateMachine.Player.transform.forward * attackInfoData.Force);
    }

    public override void Update()
    {
        base.Update();

        ForceMove();
        //if (stateMachine.Player.PlayerAnimator.GetLayerWeight(1) == 1f)
        //{
        //    //stateMachine.Player.PlayerAnimator.SetLayerWeight(1, 1);

        //}
        //else
        //{
        stateMachine.IsMeleeEquip = true;
        //}
        if (stateMachine.IsMeleeEquip)
        {
            UpdateAttackStateMachine(stateMachine.Player.PlayerAnimator, "Melee");
            UpdateAttackStateMachine(stateMachine.Player.ArmAnimator, "Melee");
        }
        else if (stateMachine.IsRangeEquip)
        {
            UpdateAttackStateMachine(stateMachine.Player.PlayerAnimator, "Range");
            UpdateAttackStateMachine(stateMachine.Player.ArmAnimator, "Range");
        }
        else
        {
            UpdateAttackStateMachine(stateMachine.Player.PlayerAnimator, "Pistol");
            UpdateAttackStateMachine(stateMachine.Player.ArmAnimator, "Pistol");
        }
    }

    private void UpdateAttackStateMachine(Animator animator, string Weapon)
    {
        float normalizedTime = GetNormalizedTime(animator, Weapon);

        if (normalizedTime < 1f)
        {
            if (normalizedTime >= attackInfoData.ForceTransitionTime)
                TryApplyForce();

            if (normalizedTime >= attackInfoData.ComboTransitionTime)
                TryComboAttack();
        }
        else
        {
            if (alreadyApplyCombo)
            {
                stateMachine.ComboIndex = attackInfoData.ComboStateIndex;
                stateMachine.ChangeState(stateMachine.ComboAttackState);
            }
            else
            {
                stateMachine.ChangeState(stateMachine.IdleState);
            }
        }
    }

    //Animator GetLayerAnimator(Animator animator, int layerIndex)
    //{
    //    AnimatorController controller = animator.runtimeAnimatorController as AnimatorController;

    //    if (controller != null && controller.layers.Length > layerIndex)
    //    {
    //        AnimatorStateMachine stateMachine = controller.layers[layerIndex].stateMachine;
    //        return stateMachine != null ? stateMachine.animator : null;
    //    }

    //    return null;
    //}
}