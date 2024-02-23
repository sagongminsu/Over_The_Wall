using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathButton : MonoBehaviour
{
    public GameObject deathPanel;


    public void ShowDeathPanel()
    {
        deathPanel.SetActive(true);
        UnlockCursor();
        PauseGame();
    }
    private void PauseGame()
    {
        Time.timeScale = 0; 
    }

    public void ResumeGame()
    {
        deathPanel.SetActive(false);
        LockCursor();
        Time.timeScale = 1;
    }
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true; 
    }
    public void RestartGame()
    {
        LockCursor();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // 메인 메뉴 씬으로 돌아갑니다.
    public void LoadMainScene()
    {
        LockCursor();
        SceneManager.LoadScene("Mainscene");
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false; 
    }

}
