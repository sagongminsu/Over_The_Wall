using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartBtn : MonoBehaviour
{

    void Start()
    {
        
    }

    public void StartGame()
    {
        LoadingSceneController.Instance.LoadScene("MainScene");
    }
}
