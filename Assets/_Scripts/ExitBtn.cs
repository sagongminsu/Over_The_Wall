using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    public Button quitButton;

    void Start()
    {
        quitButton.onClick.AddListener(Quit);
    }

    void Quit()
    {
        // 게임 종료
        Application.Quit();
    }
}
