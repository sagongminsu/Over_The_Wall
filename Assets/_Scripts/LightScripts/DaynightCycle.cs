using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DayNightCycle : MonoBehaviour
{
    
    public int Hours {  get { return hours; } }
    private int hours;
    public float Minutes { get { return minutes; } }
    private float minutes;
    public string Daytime {  get { return daytime; } }
    private string daytime;


    [Range(0.0f, 720.0f)]
    public float time; // ���� �� �ð�
    public float fullDayLength = 720f; // ���� �� �Ϸ��� ���̸� ���� �ð� 12������ ����
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


    [Header("time")]
    public TextMeshProUGUI timeText; // �ð��� ǥ���� �ؽ�Ʈ

    private int days; // ����� ��¥ ��


    private void Start()
    {
        timeRate = 720.0f / fullDayLength; // ���� �� �Ϸ�� ���� �ð��� ���� ���
        time = startTime;
        days = 0; // ���� ��¥ �ʱ�ȭ
    }

    public void Update()
    {
        time += timeRate * Time.deltaTime; // ���� �� �ð� ������Ʈ

        // �Ϸ簡 ������ ��¥ ���� �� �ð� ����
        if (time >= 720.0f)
        {
            days++;
            time = 0;
        }

        UpdateLighting(sun, sunColor, sunIntensity); // �¾� ���� ������Ʈ
        UpdateLighting(moon, moonColor, moonIntensity); // �� ���� ������Ʈ

        // �ð� �� ��¥ ǥ�� ������Ʈ
        UpdateTimeText();
        Debug.Log(Hours);
    }

    public float GetCurrentTime()
    {
        return time;
    }




    private void UpdateLighting(Light lightSource, Gradient colorGradient, AnimationCurve intensityCurve)
    {
        float intensity = intensityCurve.Evaluate(time); // �ð��� ���� ���� ���

        lightSource.transform.eulerAngles = ((time / 120.0f) - (lightSource == sun ? 0.45f : 0.55f)) * noon * 0.4f;
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
    private void UpdateTimeText()
    {
        hours = (int)(time / 30.0f);
        minutes = (time % 30.0f) * 2;
        int crruntHours = hours;
       
        daytime = crruntHours >= 12 ? "PM" : "AM";  
        if (crruntHours  > 12) crruntHours -= 12;
        if (crruntHours == 0) crruntHours = 12;

        timeText.text = "Day " + days + "\nTime: " + " " + daytime + crruntHours.ToString("00") + ":" + minutes.ToString("00");
    }
}