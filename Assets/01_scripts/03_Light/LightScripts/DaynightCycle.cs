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
    public float time; // 게임 내 시간
    public float fullDayLength = 1440f;  // 게임 내 하루의 길이를 현실 시간 24분으로 설정
    public float startTime = 0; // 시작 시간
    private float timeRate; // 게임 내 시간의 진행 속도
    public Vector3 noon; // 정오 시의 태양 위치

    [Header("Sun")]
    public Light sun; // 태양
    public Gradient sunColor; // 태양 색상
    public AnimationCurve sunIntensity; // 태양 강도

    [Header("Moon")]
    public Light moon; // 달
    public Gradient moonColor; // 달 색상
    public AnimationCurve moonIntensity; // 달 강도
    public GameObject moonObject; // 달 오브젝트

    [Header("Other Lighting")]
    public AnimationCurve lightingIntensityMultiplier; // 조명 강도
    public AnimationCurve reflectionIntensityMultiplier; // 반사 강도


    [Header("Time")]
    public TextMeshProUGUI timeText; // 시간을 표시할 텍스트

    public int Days; // 경과한 날짜 수

    public int Pause = 1;

    private void Start()
    {
        gameManager.I.dayNightCycle = this;
        dateManager = DateManager.instance;

        timeRate = 1440.0f / fullDayLength; // 게임 내 하루와 현실 시간의 비율 계산
        time = startTime;
        Days = 1; // 시작 날짜 초기화
    }

    public void Update()
    {
        time += timeRate * Time.deltaTime * Pause; // 게임 내 시간 업데이트

        // 하루가 지나면 날짜 증가 및 시간 리셋
        if (time >= 1440.0f)
        {
            Days++;
            time = 0;
        }

        UpdateLighting(sun, sunColor, sunIntensity); // 태양 조명 업데이트
        UpdateLighting(moon, moonColor, moonIntensity); // 달 조명 업데이트

        // 시간 및 날짜 표시 업데이트
        UpdateTimeText();

        
      
    }

    public float GetCurrentTime()
    {
        return time;
    }

    


    private void UpdateLighting(Light lightSource, Gradient colorGradient, AnimationCurve intensityCurve)
    {
        float intensity = intensityCurve.Evaluate(time); // 시간에 따른 강도 계산

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