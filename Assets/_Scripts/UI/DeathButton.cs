using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathButton : MonoBehaviour
{
    public GameObject deathPanel; // Inspector에서 할당

    // 사망 UI 패널을 활성화하는 함수
    public void ShowDeathPanel()
    {
        deathPanel.SetActive(true);
    }
    // 현재 게임 씬을 재시작
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // 메인 메뉴 씬으로 돌아갑니다.
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
