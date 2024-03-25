using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenActive : MonoBehaviour
{
    public GameObject[] objectsToActivate; // 활성화할 오브젝트 배열
    private bool ShopMenActivateToday = false; // 오늘 활성화되었는지 여부
    private int lastDay = -1; // 마지막으로 활성화된 날짜

    void Update()
    {
        int Day = gameManager.I.dayNightCycle.Days;
        // 날짜가 바뀌면 활성화 상태 초기화
        if (Day != lastDay)
        {
            ShopMenActivateToday = false;
            lastDay = Day;
        }

        // 설정된 시간대에만 오브젝트들을 활성화
        if (gameManager.I.CheckTime(14, 17) && !ShopMenActivateToday)
        {
            foreach (var objectToActivate in objectsToActivate)
            {
                objectToActivate.SetActive(true);
            }
            ShopMenActivateToday = true; // 오브젝트들을 활성화했다고 표시
        }
        else if (!gameManager.I.CheckTime(14, 17) && ShopMenActivateToday)
        {
            // 설정된 시간대가 아니라면 오브젝트들을 비활성화
            foreach (var objectToActivate in objectsToActivate)
            {
                objectToActivate.SetActive(false);
            }
            ShopMenActivateToday = false; // 오브젝트들을 비활성화했다고 표시
        }
    }
}
