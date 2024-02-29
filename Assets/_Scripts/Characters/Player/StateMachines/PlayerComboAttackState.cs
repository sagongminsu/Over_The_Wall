using System;
using Unity.Burst.Intrinsics;
using UnityEditor;
using UnityEngine;

public class PlayerComboAttackState : PlayerAttackState
{
    private bool alreadyAppliedForce;
    private bool alreadyApplyCombo;

    AttackInfoData attackInfoData;

    EquipManager equipManager;
    gameManager gameManager;

    public PlayerComboAttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if (equipManager == null) 
            equipManager = EquipManager.instance;
        if (gameManager == null)
            gameManager = gameManager.I;

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

        UpdateAttackStateMachine(stateMachine.Player.PlayerAnimator, GetWeaponType(equipManager));
        UpdateAttackStateMachine(stateMachine.Player.ArmAnimator, GetWeaponType(equipManager));

        if (gameManager.Open)
        {
            StopAnimation(stateMachine.Player.AnimationData.ComboAttackParameterHash);
            stateMachine.ChangeState(stateMachine.IdleState);
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

}