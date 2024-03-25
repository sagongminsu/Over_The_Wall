using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadBtn : MonoBehaviour
{
    public LoadingScene LoadingScene;

    public void LoadSavedGame(int sceneId)
    {
        // ����� ���� ������ �ε�
        gameManager.I.LoadGame();

        LoadingScene.LoadScene(sceneId);
    }
}
