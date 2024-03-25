using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartBtn : MonoBehaviour
{
    public LoadingScene LoadingScene;
    void Start()
    {
        
    }

    public void StartGame(int sceneId)
    {
        gameManager.I.isLoad = false;
        LoadingScene.LoadScene(sceneId);
    }
}
