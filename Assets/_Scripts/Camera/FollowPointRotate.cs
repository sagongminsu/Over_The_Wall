using UnityEngine;
using UnityEngine.InputSystem;

public class FollowPointRotate : MonoBehaviour
{
    public float minVerticalRotation = -90f;
    public float maxVerticalRotation = 40f;

    private PlayerInputActions inputActions;
    private float verticalRotation = 0f;
    private gameManager gameManager;
    private GoldManager goldManager;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Enable();

        gameManager = gameManager.I;
        goldManager = GoldManager.instance;
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        RotateVertical();
    }

    private void RotateVertical()
    {
        float mouseSensitivity = gameManager.GetMouseSensitivity();

        Vector2 mouseDelta = inputActions.Player.Look.ReadValue<Vector2>();

        verticalRotation += (-mouseDelta.y * mouseSensitivity * Time.deltaTime);

        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalRotation, maxVerticalRotation);

        transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}
