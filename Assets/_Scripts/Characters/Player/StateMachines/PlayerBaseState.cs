using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;
    protected readonly PlayerGroundData groundData;

    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        stateMachine = playerStateMachine;
        groundData = stateMachine.Player.Data.GroundedData;
    }

    public virtual void Enter()
    {
        AddInputActionsCallbacks();
    }

    public virtual void Exit()
    {
        RemoveInputActionsCallbacks();
    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Update()
    {
        Move();
        
    }

    private void ReadMovementInput()
    {
        stateMachine.MovementInput = stateMachine.Player.Input.PlayerActions.Movement.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();

        Rotate(movementDirection);

        Move(movementDirection);
    }

    private Vector3 GetMovementDirection()
    {
        Vector3 forward = stateMachine.MainCameraTransform.forward;
        Vector3 right = stateMachine.MainCameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        return forward * stateMachine.MovementInput.y + right * stateMachine.MovementInput.x;
    }

    private void Move(Vector3 movementDirection)
    {
        float movementSpeed = GetMovemenetSpeed();
        stateMachine.Player.Controller.Move(
            ((movementDirection * movementSpeed)
            + stateMachine.Player.ForceReceiver.Movement)
            * Time.deltaTime
            );
    }

    private void Rotate(Vector3 movementDirection)
    {
        if (movementDirection != Vector3.zero)
        {
            Transform playerTransform = stateMachine.Player.transform;
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, stateMachine.RotationDamping * Time.deltaTime);
        }
    }

    private float GetMovemenetSpeed()
    {
        float movementSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
        return movementSpeed;
    }

    protected void ForceMove()
    {
        stateMachine.Player.Controller.Move(stateMachine.Player.ForceReceiver.Movement * Time.deltaTime);
    }

    protected void StartAnimation(int animationHash)
    {
        stateMachine.Player.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        stateMachine.Player.Animator.SetBool(animationHash, false);
    }

    protected virtual void AddInputActionsCallbacks()
    {
        PlayerInput input = stateMachine.Player.Input;
        input.PlayerActions.Movement.canceled += OnMovementCanceled;
        input.PlayerActions.Run.started += OnRunStarted;

        stateMachine.Player.Input.PlayerActions.Jump.started += OnJumpStarted;

        stateMachine.Player.Input.PlayerActions.Attack.performed += OnAttackPerformed;
        stateMachine.Player.Input.PlayerActions.Attack.canceled += OnAttackCanceled;

<<<<<<< Updated upstream
        stateMachine.Player.Input.PlayerActions.Interaction.performed += OnInteractionPerformed;
        stateMachine.Player.Input.PlayerActions.Interaction.canceled += OnInteractionCanceled;
=======
        input.PlayerActions.Interaction.performed += OnInteractionPerformed;
        input.PlayerActions.Interaction.canceled += OnInteractionCanceled;

        input.PlayerActions.Aim.performed += OnAimingPerformed;
        input.PlayerActions.Aim.canceled += OnAimingCanceled;

        input.PlayerActions.Crouch.started += OnCrouchStarted;
>>>>>>> Stashed changes
    }

    protected virtual void RemoveInputActionsCallbacks()
    {
        PlayerInput input = stateMachine.Player.Input;
        input.PlayerActions.Movement.canceled -= OnMovementCanceled;
        input.PlayerActions.Run.started -= OnRunStarted;

        stateMachine.Player.Input.PlayerActions.Jump.started -= OnJumpStarted;

        stateMachine.Player.Input.PlayerActions.Attack.performed -= OnAttackPerformed;
        stateMachine.Player.Input.PlayerActions.Attack.canceled -= OnAttackCanceled;

<<<<<<< Updated upstream
        stateMachine.Player.Input.PlayerActions.Interaction.performed -= OnInteractionPerformed;
        stateMachine.Player.Input.PlayerActions.Interaction.canceled -= OnInteractionCanceled;
=======
        input.PlayerActions.Interaction.performed -= OnInteractionPerformed;
        input.PlayerActions.Interaction.canceled -= OnInteractionCanceled;

        input.PlayerActions.Aim.performed -= OnAimingPerformed;
        input.PlayerActions.Aim.canceled -= OnAimingCanceled;

        input.PlayerActions.Crouch.started -= OnCrouchStarted;
>>>>>>> Stashed changes
    }

    protected virtual void OnRunStarted(InputAction.CallbackContext context)
    {

    }

    protected virtual void OnMovementCanceled(InputAction.CallbackContext context)
    {

    }

    protected virtual void OnJumpStarted(InputAction.CallbackContext context)
    {

    }

    protected virtual void OnAttackPerformed(InputAction.CallbackContext obj)
    {
        stateMachine.IsAttacking = true;
    }

    protected virtual void OnAttackCanceled(InputAction.CallbackContext obj)
    {
        stateMachine.IsAttacking = false;
    }

    protected virtual void OnInteractionPerformed(InputAction.CallbackContext obj)
    {
        stateMachine.IsInteracting = true;
    }

    protected virtual void OnInteractionCanceled(InputAction.CallbackContext obj)
    {
        stateMachine.IsInteracting = false;
    }
<<<<<<< Updated upstream
=======

    protected virtual void OnAimingPerformed(InputAction.CallbackContext obj)
    {
        stateMachine.IsAiming = true;
    }

    protected virtual void OnAimingCanceled(InputAction.CallbackContext obj)
    {
        stateMachine.IsAiming = false;
    }

    protected virtual void OnCrouchStarted(InputAction.CallbackContext obj)
    {
        if (!stateMachine.IsCrouch)
        {
            Debug.Log("ON");
            stateMachine.IsCrouch = true;
            stateMachine.Player.Controller.height = 1.3f;
        }
        else
        {
            Debug.Log("OFF");
            stateMachine.IsCrouch = false;
            stateMachine.Player.Controller.height = 1.77f;
        }
    }
>>>>>>> Stashed changes
    protected float GetNormalizedTime(Animator animator, string tag)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

        if (animator.IsInTransition(0) && nextInfo.IsTag(tag))
        {
            return nextInfo.normalizedTime;
        }
        else if (!animator.IsInTransition(0) && currentInfo.IsTag(tag))
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0f;
        }
    }
}