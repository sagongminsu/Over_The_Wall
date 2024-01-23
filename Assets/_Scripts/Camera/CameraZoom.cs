using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] Cinemachine.CinemachineVirtualCamera virtualCamera;

    private PlayerInputActions inputActions;

    [SerializeField] private float zoomSpeed = 0.5f;
    [SerializeField] private float minFov = 40f;
    [SerializeField] private float maxFov = 100f;

    private void OnEnable()
    {
        inputActions = new PlayerInputActions();
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        float zoomInput = inputActions.Player.Zoom.ReadValue<Vector2>().y;

        if (zoomInput != 0f)
        {
            float currentFov = virtualCamera.m_Lens.FieldOfView;

            currentFov = Mathf.Clamp(currentFov - zoomInput * zoomSpeed, minFov, maxFov);

            virtualCamera.m_Lens.FieldOfView = currentFov;
        }
    }
}
