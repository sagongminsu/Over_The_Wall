using UnityEngine;

public class Bed : MonoBehaviour, IInteraction
{
    public void OnInteract()
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

        Debug.Log("Game saved!");
    }

    public string GetInteractPrompt()
    {
        return "Interaction 잠자기";
    }
}
