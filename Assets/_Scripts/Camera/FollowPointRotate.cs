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

        // ���콺 �Է¿� ���� ���� ȸ���� ����
        verticalRotation += -mouseDelta.y * rotationSpeed * Time.deltaTime;

        // ���� ȸ������ �ּ�, �ִ� ������ ����
        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalRotation, maxVerticalRotation);

        // ���� ȸ���� ����
        transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    
        
}
