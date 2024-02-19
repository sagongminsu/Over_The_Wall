using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadBtn : MonoBehaviour
{
    public Button loadGameButton;
    public gameManager GameManager;

    void Start()
    {
        loadGameButton.onClick.AddListener(LoadSavedGame);
    }

    void LoadSavedGame()
    {
        // 저장된 게임 데이터 로드
        GameManager.LoadGame();

        // MainScene을 함께 로드
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
