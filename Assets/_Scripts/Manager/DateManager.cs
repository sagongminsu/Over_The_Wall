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
        TaskName = "����ð�";
        if (CheckTime(startTime, endTime))
        {
            // Do nothing
        }
    }

    private void RollCall(int startTime, int endTime)
    {
        TaskName = "��ȣ �ð�";
        if (CheckTime(startTime, endTime))
        {
            // Do nothing
        }
    }

    private void Eat(int startTime, int endTime)
    {
        TaskName = "�Ļ� �ð�";
        if (CheckTime(startTime, endTime))
        {
            // Do nothing
        }
    }

    private void Work(int startTime, int endTime)
    {
        TaskName = "�ϰ� �ð�";
        if (CheckTime(startTime, endTime))
        {
            // Do nothing
        }
    }

    private void FreeTime(int startTime, int endTime)
    {
        TaskName = "���� �ð�";
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
            currentDay = 1; // �������� ������ �ٽ� �����Ϸ� �ʱ�ȭ
        }
    }

    bool IsWeekend(int currentDay)
    {
        // ���� ������ ����� �Ǵ� �Ͽ����̸� �ָ��� ����
        return currentDay == 6 || currentDay == 7;
    }

    public bool CheckTime(int startTime, int endTime)
    {

        // dayNightCycle.Hours�� null�� �ƴ��� Ȯ��
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
        DayText.text = Day + "��" + Week + "����";
        TimeText.text = Hour.ToString("00") + ":" + Minute.ToString("00");
        WorkText.text = TaskName;
    }
}