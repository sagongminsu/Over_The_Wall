using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractingPeople : MonoBehaviour
{
    public GameObject[] objectsToActivate; // 활성화할 오브젝트 배열
    private bool hasBeenActivatedToday = false; // 오늘 활성화되었는지 여부
    private int lastActivationDay = -1; // 마지막으로 활성화된 날짜

    void Update()
    {
        int currentDay = gameManager.I.dayNightCycle.Days;
        // 날짜가 바뀌면 활성화 상태 초기화
        if (currentDay != lastActivationDay)
        {
            hasBeenActivatedToday = false;
            lastActivationDay = currentDay;
        }

        // 설정된 시간대에만 오브젝트들을 활성화
        if (gameManager.I.CheckTime(13, 14) && !hasBeenActivatedToday)
        {
            foreach (var objectToActivate in objectsToActivate)
            {
                objectToActivate.SetActive(true);
            }
            hasBeenActivatedToday = true; // 오브젝트들을 활성화했다고 표시
        }
        else if (!gameManager.I.CheckTime(13, 14) && hasBeenActivatedToday)
        {
            // 설정된 시간대가 아니라면 오브젝트들을 비활성화
            foreach (var objectToActivate in objectsToActivate)
            {
                objectToActivate.SetActive(false);
            }
            hasBeenActivatedToday = false; // 오브젝트들을 비활성화했다고 표시
        }
    }
}