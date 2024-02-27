using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadBtn : MonoBehaviour
{
    public LoadingScene LoadingScene;

    public void LoadSavedGame(int sceneId)
    {
        // 저장된 게임 데이터 로드
        gameManager.I.LoadGame();

        LoadingScene.LoadScene(sceneId);
    }
}
