using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DateManager : MonoBehaviour
{
    public static DateManager instance;

    [HideInInspector] public int Day;
    [HideInInspector] public int Hour;
    [HideInInspector] public int Minute;

    private string Week;
    private string TaskName;
    private string[] DaysOfWeek = { "월", "화", "수", "목", "금", "토", "일" };

    [Header("Text")]
    public TextMeshProUGUI DayText;
    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI WorkText;



    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(WorkCycle());
    }

    private void Update()
    {
        UpdateText();
    }

    IEnumerator WorkCycle()
    {
        int currentDay = 1;

        while (true)
        {
            UpdateDay(ref currentDay);

            if (IsWeekend(currentDay))
            {
                yield return StartCoroutine(WeekendCycle());
            }
            else
            {
                yield return StartCoroutine(WeekdayCycle());
            }

            currentDay++;

            // 필요에 따라 게임이 끝날 조건을 추가할 수 있습니다.
            // 예를 들어, 특정 일수까지 진행하면 게임 종료 등
        }
    }

    IEnumerator WeekdayCycle()
    {
        yield return StartCoroutine(Sleep(0, 5));
        yield return StartCoroutine(RollCall(6, 6));
        yield return StartCoroutine(Eat(7, 7));
        yield return StartCoroutine(Work(8, 11));
        yield return StartCoroutine(Eat(12, 12));
        yield return StartCoroutine(Work(13, 15));
        yield return StartCoroutine(FreeTime(16, 17));
        yield return StartCoroutine(Eat(18, 18));
        yield return StartCoroutine(FreeTime(19, 20));
        yield return StartCoroutine(RollCall(21, 21));
        yield return StartCoroutine(Sleep(22, 23));
    }

    IEnumerator WeekendCycle()
    {
        yield return StartCoroutine(Sleep(0, 5));
        yield return StartCoroutine(RollCall(6, 6));
        yield return StartCoroutine(Eat(7, 7));
        yield return StartCoroutine(FreeTime(8, 11));
        yield return StartCoroutine(Eat(12, 12));
        yield return StartCoroutine(FreeTime(13, 17));
        yield return StartCoroutine(Eat(18, 18));
        yield return StartCoroutine(FreeTime(19, 20));
        yield return StartCoroutine(RollCall(21, 21));
        yield return StartCoroutine(Sleep(22, 23));
    }

    IEnumerator Sleep(int startTime, int endTime)
    {
        TaskName = "수면시간";

        while (CheckTime(startTime, endTime))
        {
            yield return null;
        }

        yield return new WaitForEndOfFrame();
    }

    IEnumerator RollCall(int startTime, int endTime)
    {
        TaskName = "점호 시간";
        while (CheckTime(startTime, endTime))
        {
            yield return null;
        }

        yield return new WaitForEndOfFrame();
    }


    IEnumerator Eat(int startTime, int endTime)
    {
        TaskName = "식사 시간";
        while (CheckTime(startTime, endTime))
        {
            yield return null;
        }

        yield return new WaitForEndOfFrame();
    }

    IEnumerator Work(int startTime, int endTime)
    {
        TaskName = "일과 시간";
        while (CheckTime(startTime, endTime))
        {
            yield return null;
        }

        yield return new WaitForEndOfFrame();
    }

    IEnumerator FreeTime(int startTime, int endTime)
    {
        TaskName = "자유 시간";
        while (CheckTime(startTime, endTime))
        {
            yield return null;
        }

        yield return new WaitForEndOfFrame();
    }

    void UpdateDay(ref int currentDay)
    {
        currentDay %= 7;
        
        Week = DaysOfWeek[currentDay - 1];
    }

    bool IsWeekend(int currentDay)
    {
        // 현재 요일이 토요일 또는 일요일이면 주말로 간주
        return currentDay == 6 || currentDay == 7;
    }

    public bool CheckTime(int startTime, int endTime)
    {

        // dayNightCycle.Hours가 null이 아닌지 확인
        if (Hour >= startTime && Hour <= endTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UpdateText()
    {
        int adjustedMinute = (Minute / 10) * 10;

        DayText.text = Day + "일 " + Week + "요일";
        TimeText.text = Hour.ToString("00") + ":" + adjustedMinute.ToString("00");
        WorkText.text = TaskName;
    }
}