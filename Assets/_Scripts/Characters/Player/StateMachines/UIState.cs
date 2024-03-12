using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIState : PlayerBaseState
{
    public UIState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.0f;
    }

    public override void Exit()
    {
        base.Exit();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
    }

    public override void Update()
    {
        base.Update();
        if (stateMachine.Player.Pause.CheckActive() == false)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }

    protected override void OnInvenStarted(InputAction.CallbackContext context)
    {
        base.OnInvenStarted(context);
        if (stateMachine.Player.Inven.CheckActive() == true && stateMachine.Player.Pause.CheckActive() == false)
        {
            stateMachine.Player.Inven.ActiveUI(false);
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }

    protected override void OnPauseStarted(InputAction.CallbackContext context)
    {
        base.OnPauseStarted(context);
        if (stateMachine.Player.Pause.CheckActive() == true)
        {
            stateMachine.Player.Pause.ActiveUI(false);
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}
