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
        // ����� ���� ������ �ε�
        GameManager.LoadGame();

        // MainScene�� �Բ� �ε�
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
