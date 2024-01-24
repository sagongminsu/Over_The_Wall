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
<<<<<<< Updated upstream
=======
    public PlayerAimingState AimingState { get; }
    public PlayerCrouchIdleState CrouchIdleState { get; }
    public PlayerCrouchWalkState CrouchWalkState { get; }
>>>>>>> Stashed changes

    // 
    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;

    public float JumpForce { get; set; }

    public bool IsAttacking { get; set; }
    public bool IsInteracting { get; set; }
<<<<<<< Updated upstream
=======
    public bool IsAiming { get; set; }
    public bool IsCrouch { get; set; }
>>>>>>> Stashed changes
    public int ComboIndex { get; set; }

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
<<<<<<< Updated upstream
=======
        AimingState = new PlayerAimingState(this);
        CrouchIdleState = new PlayerCrouchIdleState(this);
        CrouchWalkState = new PlayerCrouchWalkState(this);
>>>>>>> Stashed changes

        MainCameraTransform = Camera.main.transform;

        MovementSpeed = player.Data.GroundedData.BaseSpeed;
        RotationDamping = player.Data.GroundedData.BaseRotationDamping;
    }
}