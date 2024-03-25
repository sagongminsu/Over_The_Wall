using UnityEngine;
using TMPro;
using System;

public class DayNightCycle : MonoBehaviour
{
    DateManager dateManager;
    public int Hours {  get { return hours; } }
    private int hours;
    public void SetHours(float newHours)
    {
        hours = (int)newHours;
    }
    [Range(0.0f, 1440.0f)]
    public float time; // ���� �� �ð�
    public float fullDayLength = 1440f;  // ���� �� �Ϸ��� ���̸� ���� �ð� 24������ ����
    public float startTime = 0; // ���� �ð�
    private float timeRate; // ���� �� �ð��� ���� �ӵ�
    public Vector3 noon; // ���� ���� �¾� ��ġ

    [Header("Sun")]
    public Light sun; // �¾�
    public Gradient sunColor; // �¾� ����
    public AnimationCurve sunIntensity; // �¾� ����

    [Header("Moon")]
    public Light moon; // ��
    public Gradient moonColor; // �� ����
    public AnimationCurve moonIntensity; // �� ����
    public GameObject moonObject; // �� ������Ʈ

    [Header("Other Lighting")]
    public AnimationCurve lightingIntensityMultiplier; // ���� ����
    public AnimationCurve reflectionIntensityMultiplier; // �ݻ� ����


    [Header("Time")]
    public TextMeshProUGUI timeText; // �ð��� ǥ���� �ؽ�Ʈ

    public int Days; // ����� ��¥ ��

    public int Pause = 1;

    private void Start()
    {
        gameManager.I.dayNightCycle = this;
        dateManager = DateManager.instance;

        timeRate = 1440.0f / fullDayLength; // ���� �� �Ϸ�� ���� �ð��� ���� ���
        time = startTime;
        Days = 1; // ���� ��¥ �ʱ�ȭ
    }

    public void Update()
    {
        time += timeRate * Time.deltaTime * Pause; // ���� �� �ð� ������Ʈ

        // �Ϸ簡 ������ ��¥ ���� �� �ð� ����
        if (time >= 1440.0f)
        {
            Days++;
            time = 0;
        }

        UpdateLighting(sun, sunColor, sunIntensity); // �¾� ���� ������Ʈ
        UpdateLighting(moon, moonColor, moonIntensity); // �� ���� ������Ʈ

        // �ð� �� ��¥ ǥ�� ������Ʈ
        UpdateTimeText();

        
      
    }

    public float GetCurrentTime()
    {
        return time;
    }

    


    private void UpdateLighting(Light lightSource, Gradient colorGradient, AnimationCurve intensityCurve)
    {
        float intensity = intensityCurve.Evaluate(time); // �ð��� ���� ���� ���

        lightSource.transform.eulerAngles = ((time / 120.0f) - (lightSource == sun ? 0.35f : 0.65f)) * noon * 0.4f;
        lightSource.color = colorGradient.Evaluate(time);
        lightSource.intensity = intensity;

        if (lightSource == moon)
        {
            if (lightSource.intensity == 0 && moonObject.activeInHierarchy)
                moonObject.SetActive(false);
            else if (lightSource.intensity > 0 && !moonObject.activeInHierarchy)
                moonObject.SetActive(true);
        }
    }
    public void UpdateTimeText()
    {
        dateManager.Day = Days;
        dateManager.Hour = (int)(time / 60.0f);
        dateManager.Minute = (int)time % 60;
        hours = (int)(time / 60.0f);
        int minutes = (int)time % 60;
        int crrentHours = hours;
        string daytime = hours >= 12 ? "PM" : "AM";
        if (crrentHours > 12) crrentHours -= 12;
        if (crrentHours == 0) crrentHours = 12;

        
    }

}