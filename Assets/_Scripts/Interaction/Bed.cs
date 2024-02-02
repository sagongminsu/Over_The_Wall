

using UnityEngine;

public class Bed : MonoBehaviour, IInteraction
{
    public void OnInteract()
    {
        //ħ������ ���� �ִϸ��̼� ����
        //���� �������� ����
        //�ǰ���,ü�� �� ȸ��
        gameManager.I.playerConditions.health.curValue = gameManager.I.playerConditions.health.maxValue;
        gameManager.I.playerConditions.stamina.curValue = gameManager.I.playerConditions.stamina.maxValue;

        // ���� ����
        gameManager.I.SaveGame();
    }

    public string GetInteractPrompt()
    {
        return "Interaction ���ڱ�";
    }
}
