using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiStateMachine : StateMachine
{

    public Ai Ai { get; }

    public Transform Target { get; private set; }
    public AiPatrollingState PatrollingState { get; private set; }
    public AiIdleState IdleingState { get; }
    public AiChasingState ChasingState { get; }
    public AiAttackState AttackState { get; }

    public AiHitState HitState { get; }

    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;


    // AI가 공격 받았는지 여부를 나타내는 변수 
    public bool IsAttacked { get; set; } = false;
    public void OnAttacked()
    {
        IsAttacked = true;
        if (IsInPlayerChaseRange() && IsAttacked)
        {
            ChangeState(ChasingState);
        }
        else
        {
            ChangeState(PatrollingState);
        }
    }



    public AiStateMachine(Ai ai, List<Transform> waypoints)
    {
        Ai = ai;
        Target = GameObject.FindGameObjectWithTag("Player").transform;

        IdleingState = new AiIdleState(this);
        ChasingState = new AiChasingState(this);
        AttackState = new AiAttackState(this);
        HitState = new AiHitState(this);

        MovementSpeed = ai.Data.GroundedData.BaseSpeed;
        RotationDamping = ai.Data.GroundedData.BaseRotationDamping;
        PatrollingState = new AiPatrollingState(this, waypoints);
    }


    public bool IsInPlayerChaseRange()
    {
        float playerDistanceSqr = (Target.transform.position - Ai.transform.position).sqrMagnitude;
        return playerDistanceSqr <= Ai.Data.PlayerChasingRange * Ai.Data.PlayerChasingRange;
    }
}
