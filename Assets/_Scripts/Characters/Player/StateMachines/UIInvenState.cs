using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInvenState : PlayerBaseState
{
    public UIInvenState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.0f;
        stateMachine.Player.Inven.ActiveUI(true);
    }

    public override void Exit()
    {
        base.Exit();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        stateMachine.Player.Inven.ActiveUI(false);
    }


    protected override void OnInvenStarted(InputAction.CallbackContext context)
    {
        base.OnInvenStarted(context);
        if (stateMachine.Player.Inven.CheckActive() == true && stateMachine.Player.Pause.CheckActive() == false)
            stateMachine.ChangeState(stateMachine.IdleState);
    }
}
