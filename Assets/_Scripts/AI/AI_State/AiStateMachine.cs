using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiStateMachine : StateMachine
{
    public Ai Ai { get; }

    public Transform Target { get; private set; }

    public AiIdleState IdleingState { get; }
    public AiChasingState ChasingState { get; }
    public AiAttackState AttackState { get; }

    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;

    public AiStateMachine(Ai ai)
    {
        Ai = ai;
        Target = GameObject.FindGameObjectWithTag("Player").transform;

        IdleingState = new AiIdleState(this);
        ChasingState = new AiChasingState(this);
        AttackState = new AiAttackState(this);

        MovementSpeed = ai.Data.GroundedData.BaseSpeed;
        RotationDamping = ai.Data.GroundedData.BaseRotationDamping;
    }
}
