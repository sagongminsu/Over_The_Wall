using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bed : MonoBehaviour, IInteraction
{
    public Image fadePanel;
    private bool dayIncremented = false;
    void Awake()
    {
        if (fadePanel == null)
        {
            fadePanel = GetComponent<Image>();
        }

        fadePanel.color = new Color(0f, 0f, 0f, 0f);
    }

    public void OnInteract()
    {
        if (gameManager.I.dayNightCycle.Hours > 21 || gameManager.I.dayNightCycle.Hours < 5)
        {
            StartCoroutine(FadeOutAndIn());
            if (gameManager.I.dayNightCycle.Days == 0)
            {
                QuestManager.instance.CompleteQuest(5);
            }
        }
        else
        {
            Debug.Log("�� �ð����� �� �� �����ϴ�.");
            // �ٸ� ���� �Ǵ� �޽����� �߰��� �� �ֽ��ϴ�.
        }
    }

    IEnumerator FadeOutAndIn()
    {
        if (gameManager.I.CheckTime(1140, 1439) && !dayIncremented)
        {
            gameManager.I.dayNightCycle.Days++;
            dayIncremented = true;
            gameManager.I.dayNightCycle.SetHours(6);
        }
        else if (gameManager.I.CheckTime(1, 360) && !dayIncremented)
        {
            gameManager.I.dayNightCycle.Days++;
            dayIncremented = true;
            gameManager.I.dayNightCycle.SetHours(6);
        }
        else
        {
            dayIncremented = false;
        }

        yield return StartCoroutine(FadeOut());

        yield return new WaitForSeconds(1.0f);

        StartCoroutine(FadeInAndSave());
    }


    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < 1.0f)
        {
            Color currentColor = fadePanel.color;
            fadePanel.color = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(0f, 1f, elapsedTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadePanel.color = new Color(0f, 0f, 0f, 1f);
    }

    IEnumerator FadeInAndSave()
    {
        float elapsedTime = 0f;
        float fadeInDuration = 1.0f;
        float targetTime = 360; // AM 06:00
        float initialTime = gameManager.I.dayNightCycle.GetCurrentTime();

        while (elapsedTime < fadeInDuration)
        {
            Color currentColor = fadePanel.color;
            fadePanel.color = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(1f, 0f, elapsedTime / fadeInDuration));

            gameManager.I.dayNightCycle.time = Mathf.Lerp(initialTime, targetTime, elapsedTime / fadeInDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadePanel.color = new Color(0f, 0f, 0f, 0f);

        SaveAndUpdateTime();
    }


    void SaveAndUpdateTime()
    {
        gameManager.I.SaveGame();

        float currentTime = gameManager.I.dayNightCycle.GetCurrentTime();

        if (gameManager.I.CheckTime(1140, 1439) || gameManager.I.CheckTime(1, 360))
        {
            Debug.Log("Game saved! Time updated!");

            gameManager.I.dayNightCycle.SetHours(360);
            gameManager.I.dayNightCycle.UpdateTimeText();
            // ���⼭ �߰����� �۾��� �����ϼ���.
            // ��: SceneManager.LoadScene("YourNextScene");
        }
        else
        {
            Debug.Log("�� �ð����� ������ �� �����ϴ�.");
        }
    }


    public string GetInteractPrompt()
    {
        return "Interaction ���ڱ�";
    }
}