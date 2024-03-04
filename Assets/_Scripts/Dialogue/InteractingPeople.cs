using UnityEngine;

public class InteractingPeople : MonoBehaviour
{
    // NPC가 활성화되기 시작하는 시간
    public int activateStartHour = 13;
    // NPC가 비활성화되기 시작하는 시간
    public int activateEndHour = 15;

    // Update 메소드는 매 프레임마다 호출됩니다.
    void Update()
    {

        int currentHour = gameManager.I.dayNightCycle.Hours;


        bool shouldBeActive = currentHour >= activateStartHour && currentHour < activateEndHour;


        gameObject.SetActive(shouldBeActive);
    }

}