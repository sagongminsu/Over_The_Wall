using TMPro;
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

        RotateByMouseDelta();
        //Rotate(movementDirection);

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

    //private void Rotate(Vector3 movementDirection)
    //{
    //    if (movementDirection != Vector3.zero)
    //    {
    //        Transform playerTransform = stateMachine.Player.transform;
    //        Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
    //        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, stateMachine.RotationDamping * Time.deltaTime);
    //    }
    //}

    private float GetMovemenetSpeed()
    {
        float movementSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
        return movementSpeed;
    }

    //private void CameraPosition(float Height)
    //{
    //    float smoothSpeed = 5f;
    //    Vector3 targetPosition = new Vector3(stateMachine.MainCameraTransform.position.x, Height, stateMachine.MainCameraTransform.position.z);
    //    stateMachine.MainCameraTransform.position = Vector3.Lerp(stateMachine.MainCameraTransform.position, targetPosition, smoothSpeed * Time.deltaTime);
    //}
    protected void ForceMove()
    {
        stateMachine.Player.Controller.Move(stateMachine.Player.ForceReceiver.Movement * Time.deltaTime);
    }

    private void RotateByMouseDelta()
    {
        Vector2 mouseDelta = stateMachine.Player.Input.PlayerActions.Look.ReadValue<Vector2>();
        float mouseX = mouseDelta.x;

        if (Mathf.Abs(mouseX) > 0.1f)
        {
            Transform playerTransform = stateMachine.Player.transform;
            Vector3 rotationAmount = new Vector3(0, mouseX * stateMachine.MouseSensitivity, 0);
            Quaternion deltaRotation = Quaternion.Euler(rotationAmount * Time.deltaTime);
            playerTransform.rotation *= deltaRotation;
        }
    }

    protected void StartAnimation(int animationHash)
    {
        stateMachine.Player.PlayerAnimator.SetBool(animationHash, true);
        stateMachine.Player.ArmAnimator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        stateMachine.Player.PlayerAnimator.SetBool(animationHash, false);
        stateMachine.Player.ArmAnimator.SetBool(animationHash, false);
    }

    protected virtual void AddInputActionsCallbacks()
    {
        PlayerInput input = stateMachine.Player.Input;
        input.PlayerActions.Movement.canceled += OnMovementCanceled;

        input.PlayerActions.Run.started += OnRunStarted;
        input.PlayerActions.Run.canceled += OnRunCanceled;

        input.PlayerActions.Jump.started += OnJumpStarted;

        input.PlayerActions.Attack.performed += OnAttackPerformed;
        input.PlayerActions.Attack.canceled += OnAttackCanceled;

        input.PlayerActions.Interaction.started += OnInteractionStarted;
        input.PlayerActions.Interaction.canceled += OnInteractionCanceled;

        input.PlayerActions.Aim.performed += OnAimingPerformed;
        input.PlayerActions.Aim.canceled += OnAimingCanceled;

        input.PlayerActions.Crouch.started += OnCrouchStarted;
    }

    protected virtual void RemoveInputActionsCallbacks()
    {
        PlayerInput input = stateMachine.Player.Input;
        input.PlayerActions.Movement.canceled -= OnMovementCanceled;

        input.PlayerActions.Run.started -= OnRunStarted;
        input.PlayerActions.Run.canceled -= OnRunCanceled;

        input.PlayerActions.Jump.started -= OnJumpStarted;

        input.PlayerActions.Attack.performed -= OnAttackPerformed;
        input.PlayerActions.Attack.canceled -= OnAttackCanceled;

        input.PlayerActions.Interaction.started -= OnInteractionStarted;
        input.PlayerActions.Interaction.canceled -= OnInteractionCanceled;

        input.PlayerActions.Aim.performed -= OnAimingPerformed;
        input.PlayerActions.Aim.canceled -= OnAimingCanceled;

        input.PlayerActions.Crouch.started -= OnCrouchStarted;
    }

    protected virtual void OnRunStarted(InputAction.CallbackContext context)
    {

    }
    protected virtual void OnRunCanceled(InputAction.CallbackContext context)
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

    protected virtual void OnInteractionStarted(InputAction.CallbackContext obj)
    {
        stateMachine.IsInteracting = true;
    }

    protected virtual void OnInteractionCanceled(InputAction.CallbackContext obj)
    {
        stateMachine.IsInteracting = false;
    }

    protected virtual void OnAimingPerformed(InputAction.CallbackContext obj)
    {
        stateMachine.IsAiming = true;
        stateMachine.Player.Aim.CheckWeaponType(true);
    }

    protected virtual void OnAimingCanceled(InputAction.CallbackContext obj)
    {
        stateMachine.IsAiming = false;
        stateMachine.Player.Aim.ResetCrossHair();
    }

    protected virtual void OnCrouchStarted(InputAction.CallbackContext obj)
    {
        if (!stateMachine.IsCrouch)
        {
            stateMachine.IsCrouch = true;
            AdjustCharacterHeight(1.3f);
        }
        else
        {
            stateMachine.IsCrouch = false;
            AdjustCharacterHeight(1.77f);
        }
    }

    private void AdjustCharacterHeight(float height)
    {
        stateMachine.Player.Controller.height = height;
        stateMachine.Player.Controller.center = new Vector3(0, height * 0.5f, 0);
    }

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