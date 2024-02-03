using System.Collections;
using UnityEngine;

public class Bed : MonoBehaviour, IInteraction
{
    public CanvasGroup fadePanel; // Reference to your fade panel

    public void OnInteract()
    {
        StartCoroutine(FadeOutAndIn());
    }

    IEnumerator FadeOutAndIn()
    {
        yield return StartCoroutine(FadeOut());
        yield return new WaitForSeconds(2.0f); // Optional delay between fade out and fade in
        FadeInAndSave();
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < 1.0f)
        {
            fadePanel.alpha = Mathf.Lerp(0f, 1f, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadePanel.alpha = 1f;
    }

    void FadeInAndSave()
    {
        float currentTime = gameManager.I.dayNightCycle.GetCurrentTime();

        if (gameManager.I.CheckTime(1140, 1439))
        {
            gameManager.I.dayNightCycle.Days++;
            gameManager.I.dayNightCycle.SetHours(360);
        }
        else if (gameManager.I.CheckTime(1, 360))
        {
            gameManager.I.dayNightCycle.SetHours(360);
        }
        else
        {
            Debug.Log("아직 잘 수 없습니다..");
            return;
        }

        gameManager.I.playerConditions.health.curValue = gameManager.I.playerConditions.health.maxValue;
        gameManager.I.playerConditions.stamina.curValue = gameManager.I.playerConditions.stamina.maxValue;

        gameManager.I.SaveGame();

        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < 1.0f)
        {
            fadePanel.alpha = Mathf.Lerp(1f, 0f, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadePanel.alpha = 0f;
        Debug.Log("Game saved!");
    }

    public string GetInteractPrompt()
    {
        return "Interaction 잠자기";
    }
}
