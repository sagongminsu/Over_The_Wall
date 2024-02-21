using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivitySlider : MonoBehaviour
{
    public Slider sensitivitySlider;
    public TextMeshProUGUI sensitivityText;
    private gameManager gameManager;

    private void Awake()
    {
        gameManager = gameManager.I;
    }

    private void Start()
    {
        if (gameManager != null)
        {
            sensitivitySlider.value = gameManager.GetMouseSensitivity();
            sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity);
            UpdateSensitivity(gameManager.GetMouseSensitivity());
        }
        else
        {
            Debug.LogError("gameManager instance is null in MouseSensitivitySlider.");
        }
    }

    public void UpdateSensitivity(float value)
    {
        if (gameManager != null)
        {
            gameManager.SetMouseSensitivity(value);
            sensitivityText.text = value.ToString("F1");
        }
        else
        {
            Debug.LogError("gameManager instance is null in UpdateSensitivity.");
        }
    }
}
