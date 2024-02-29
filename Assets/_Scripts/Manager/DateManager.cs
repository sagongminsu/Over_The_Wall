using TMPro;
using UnityEngine;

public class DateManager : MonoBehaviour
{
    public static DateManager instance;

    [HideInInspector] public int Day;
    [HideInInspector] public int Hour;
    [HideInInspector] public int Minute;

    private string Week;
    private string TaskName;

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
        WorkCycle();
    }

    private void Update()
    {
        UpdateText();
    }

    private void WorkCycle()
    {
        int currentDay = 1;

        while (true)
        {
            if (IsWeekend(currentDay))
            {
                WeekendCycle();
            }
            else
            {
                WeekdayCycle();
            }

            UpdateDay(ref currentDay);

            // Add game end condition if needed
        }
    }

    private void WeekdayCycle()
    {
        Sleep(0, 5);
        RollCall(6, 6);
        Eat(7, 7);
        Work(8, 11);
        Eat(12, 12);
        Work(13, 16);
        FreeTime(17, 17);
        Eat(18, 18);
        FreeTime(19, 20);
        RollCall(21, 21);
        Sleep(22, 23);
    }

    private void WeekendCycle()
    {
        Sleep(0, 5);
        RollCall(6, 6);
        Eat(7, 7);
        FreeTime(8, 11);
        Eat(12, 12);
        FreeTime(13, 17);
        Eat(18, 18);
        FreeTime(19, 20);
        RollCall(21, 21);
        Sleep(22, 23);
    }

    private void Sleep(int startTime, int endTime)
    {
        TaskName = "수면시간";
        if (CheckTime(startTime, endTime))
        {
            // Do nothing
        }
    }

    private void RollCall(int startTime, int endTime)
    {
        TaskName = "점호 시간";
        if (CheckTime(startTime, endTime))
        {
            // Do nothing
        }
    }

    private void Eat(int startTime, int endTime)
    {
        TaskName = "식사 시간";
        if (CheckTime(startTime, endTime))
        {
            // Do nothing
        }
    }

    private void Work(int startTime, int endTime)
    {
        TaskName = "일과 시간";
        if (CheckTime(startTime, endTime))
        {
            // Do nothing
        }
    }

    private void FreeTime(int startTime, int endTime)
    {
        TaskName = "자유 시간";
        if (CheckTime(startTime, endTime))
        {
            // Do nothing
        }
    }

    void UpdateDay(ref int currentDay)
    {
        currentDay++;
        if (currentDay > 7)
        {
            currentDay = 1; // 일주일이 지나면 다시 월요일로 초기화
        }
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
        DayText.text = Day + "일" + Week + "요일";
        TimeText.text = Hour.ToString("00") + ":" + Minute.ToString("00");
        WorkText.text = TaskName;
    }
}