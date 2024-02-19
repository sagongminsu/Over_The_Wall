using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    EquipManager equipManager = EquipManager.instance;
    public PlayerAttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0;
        base.Enter();
        StartAnim();

        if (stateMachine.Player != null)
        {
            if (stateMachine.Player.Weapon_R != null)
            {
                stateMachine.Player.Weapon_R.ToggleColliders(true);
            }

            if (stateMachine.Player.Weapon_L != null)
            {
                stateMachine.Player.Weapon_L.ToggleColliders(true);
            }
            else
            {
                Debug.LogError("Weapon null");
            }
        }
        else
        {
            Debug.LogError("Player null");
        }
    }

    public override void Exit()
    {
        base.Exit();

        StopAnim();

        if (stateMachine.Player != null)
        {
            if (stateMachine.Player.Weapon_R != null)
            {
                stateMachine.Player.Weapon_R.ToggleColliders(false);
            }

            if (stateMachine.Player.Weapon_L != null)
            {
                stateMachine.Player.Weapon_L.ToggleColliders(false);
            }
            else
            {
                Debug.LogError("Weapon null");
            }
        }
        else
        {
            Debug.LogError("Player null");
        }
    }

    private void HandleAttack(AiStateMachine aiStateMachine)
    {
        // AI에게 공격이 감지되었다고 알림
        aiStateMachine.OnAttacked();
    }

    protected void HandleWeaponType(bool startAnimation, bool stopAnimation)
    {
        string weaponType = GetWeaponType(equipManager);

        if (startAnimation)
        {
            if (weaponType == "Pistol")
                StartAnimation(stateMachine.Player.AnimationData.AttackParameterHash);
            else if (weaponType == "OHMelee")
                StartAnimation(stateMachine.Player.AnimationData.MeleeAttackParameterHash);
        }
        else if (stopAnimation)
        {
            if (weaponType == "Pistol")
                StopAnimation(stateMachine.Player.AnimationData.AttackParameterHash);
            else if (weaponType == "OHMelee")
                StopAnimation(stateMachine.Player.AnimationData.MeleeAttackParameterHash);
        }
    }

    protected string GetWeaponType(EquipManager equipManager)
    {
        if (equipManager.isEquipped && equipManager.curEquip.GetComponent<ItemData_>() != null)
        {
            WeaponType weaponTypeValue = equipManager.curEquip.GetComponent<ItemData_>().weaponType;

            switch (weaponTypeValue)
            {
                case WeaponType.OHMelee:
                    return "OHMelee";
                case WeaponType.THMelee:
                    return "THMelee";
                case WeaponType.Range:
                    return "Range";
            }
        }

        return "Pistol";
    }

    private void StartAnim()
    {
        HandleWeaponType(true, false);
    }

    private void StopAnim()
    {
        HandleWeaponType(false, true);
    }
}