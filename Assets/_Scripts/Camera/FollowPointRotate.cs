using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class FollowPointRotate : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    public float minVerticalRotation = -90f;
    public float maxVerticalRotation = 40f;

    private PlayerInputActions inputActions;
    private float verticalRotation = 0f;

    void OnEnable()
    {
        inputActions = new PlayerInputActions();
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        Vector2 mouseDelta = inputActions.Player.Look.ReadValue<Vector2>();

        // 마우스 입력에 따라 수직 회전값 축적
        verticalRotation += -mouseDelta.y * rotationSpeed * Time.deltaTime;

        // 수직 회전값을 최소, 최대 값으로 제한
        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalRotation, maxVerticalRotation);

        // 수직 회전값 적용
        transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    
        
}
