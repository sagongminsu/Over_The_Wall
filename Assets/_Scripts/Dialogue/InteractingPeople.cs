using UnityEngine;

public class InteractingPeople : MonoBehaviour
{
    // NPC�� Ȱ��ȭ�Ǳ� �����ϴ� �ð�
    public int activateStartHour = 13;
    // NPC�� ��Ȱ��ȭ�Ǳ� �����ϴ� �ð�
    public int activateEndHour = 15;

    // Update �޼ҵ�� �� �����Ӹ��� ȣ��˴ϴ�.
    void Update()
    {

        int currentHour = gameManager.I.dayNightCycle.Hours;


        bool shouldBeActive = currentHour >= activateStartHour && currentHour < activateEndHour;


        gameObject.SetActive(shouldBeActive);
    }

}