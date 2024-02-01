using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public PlayerAttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0;
        base.Enter();

        StartAnimation(stateMachine.Player.AnimationData.AttackParameterHash);

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

        StopAnimation(stateMachine.Player.AnimationData.AttackParameterHash);

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
}