using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathButton : MonoBehaviour
{
    public GameObject deathPanel; // Inspector���� �Ҵ�

    // ��� UI �г��� Ȱ��ȭ�ϴ� �Լ�
    public void ShowDeathPanel()
    {
        deathPanel.SetActive(true);
    }
    // ���� ���� ���� �����
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // ���� �޴� ������ ���ư��ϴ�.
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
