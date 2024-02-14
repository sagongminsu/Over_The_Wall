using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }

    // States
    public PlayerIdleState IdleState { get; }
    public PlayerWalkState WalkState { get; }
    public PlayerRunState RunState { get; }
    public PlayerJumpState JumpState { get; }
    public PlayerFallState FallState { get; }
    public PlayerComboAttackState ComboAttackState { get; }
    public PlayerInteractState InteractState { get; }

    public PlayerAimingIdleState AimingIdleState { get; }
    public PlayerAimingWalkState AimingWalkState { get; }
    public PlayerCrouchIdleState CrouchIdleState { get; }
    public PlayerCrouchWalkState CrouchWalkState { get; }

    public PlayerSitState SitState { get; }

    // 
    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;

    public float JumpForce { get; set; }

    public bool IsAttacking { get; set; }
    public bool IsInteracting { get; set; }

    public bool IsAiming { get; set; }
    public bool IsCrouch { get; set; }

    public bool IsIdle { get; set; }
    public bool IsWalk {  get; set; }
    public bool IsRun { get; set; }
    public bool IsMeleeEquip { get; set; }
    public bool IsRangeEquip { get; set; }

    public int ComboIndex { get; set; }

    public float MouseSensitivity = 5.0f;

    public Transform MainCameraTransform { get; set; }

    public PlayerStateMachine(Player player)
    {
        this.Player = player;

        IdleState = new PlayerIdleState(this);
        WalkState = new PlayerWalkState(this);
        RunState = new PlayerRunState(this);
        JumpState = new PlayerJumpState(this);
        FallState = new PlayerFallState(this);
        ComboAttackState = new PlayerComboAttackState(this);
        InteractState = new PlayerInteractState(this);
        AimingIdleState = new PlayerAimingIdleState(this);
        AimingWalkState = new PlayerAimingWalkState(this);
        CrouchIdleState = new PlayerCrouchIdleState(this);
        CrouchWalkState = new PlayerCrouchWalkState(this);
        SitState = new PlayerSitState(this);

        MainCameraTransform = Camera.main.transform;

        MovementSpeed = player.Data.GroundedData.BaseSpeed;
        RotationDamping = player.Data.GroundedData.BaseRotationDamping;
    }
}