using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadBtn : MonoBehaviour
{
    public Button loadGameButton;

    void Start()
    {
        //loadGameButton.onClick.AddListener(LoadSavedGame);
    }

    public void LoadSavedGame()
    {
        // ����� ���� ������ �ε�
        gameManager.I.LoadGame();

        // MainScene�� �Բ� �ε�
        //SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
