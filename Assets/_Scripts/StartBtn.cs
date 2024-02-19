using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartBtn : MonoBehaviour
{
    public Button StartGameButton;

    void Start()
    {
        StartGameButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        // MainScene을 함께 로드
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
