using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player player { get; }

    //states
   // public PlayerIdleState idleState { get; }

    public Vector2 MovemnetInput { get; set; }
    public float MovemnetSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovemnetSpeedModifier { get; private set; } = 1f;

    public float JumpForce { get; set; }

    public Transform MainCameraTransform { get; set; }

    public PlayerStateMachine(Player player)
    {
        this.player = player;

        //idleState = new PlayerIdleState(this);

        MainCameraTransform = Camera.main.transform;

        MovemnetSpeed = player.Data.GroundData.BaseSpeed;
        RotationDamping = player.Data.GroundData.BaseRotationDamping;
    }

}
