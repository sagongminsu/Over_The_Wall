

using UnityEngine;

public class Bed : MonoBehaviour, IInteraction
{
    public void OnInteract()
    {
        //침대위에 눕기 애니메이션 실행
        //현재 시점으로 저장
        //피곤함,체력 등 회복
        gameManager.I.playerConditions.health.curValue = gameManager.I.playerConditions.health.maxValue;
        gameManager.I.playerConditions.stamina.curValue = gameManager.I.playerConditions.stamina.maxValue;

        // 게임 저장
        gameManager.I.SaveGame();
    }

    public string GetInteractPrompt()
    {
        return "Interaction 잠자기";
    }
}
