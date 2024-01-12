//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;
//using System;

//public class DayNightCycle : MonoBehaviour
//{
//    [Range(0.0f, 720.0f)]
//    public float time;
//    public float fullDayLength;
//    public float startTime = 0.4f;
//    private float timeRate;
//    public Vector3 noon;

//    [Header("Sun")]
//    public Light sun;
//    public Gradient sunColor;
//    public AnimationCurve sunIntensity;

//    [Header("Moon")]
//    public Light moon;
//    public Gradient moonColor;
//    public AnimationCurve moonIntensity;


//    [Header("Other Lighting")]
//    public AnimationCurve lightingIntensityMultiplier;
//    public AnimationCurve reflectionIntensityMultiplier;

//    public TextMeshProUGUI timeText;

//    private void Start()
//    {
//        timeRate = 1.0f / fullDayLength;
//        time = startTime;


//    }



//    private void Update()
//    {
//        time = (time + timeRate * Time.deltaTime) % 720.0f;

//        UpdateLighting(sun, sunColor, sunIntensity);
//        UpdateLighting(moon, moonColor, moonIntensity);

//        RenderSettings.ambientIntensity = lightingIntensityMultiplier.Evaluate(time);
//        RenderSettings.reflectionIntensity = reflectionIntensityMultiplier.Evaluate(time);

//        // 시간을 시:분 형식으로 변환
//        float hours = time / 720.0f * 24.0f;
//        int displayHours = (int)hours;
//        int displayMinutes = (int)((hours - displayHours) * 60);

//        timeText.text = "Time: " + displayHours.ToString("00") + ":" + displayMinutes.ToString("00");
//    }

//    void UpdateLighting(Light lightSource, Gradient colorGradiant, AnimationCurve intensityCurve)
//    {
//        float intensity = intensityCurve.Evaluate(time);

//        lightSource.transform.eulerAngles = (time - (lightSource == sun ? 0.25f : 0.75f)) * noon * 0.4f;
//        lightSource.color = colorGradiant.Evaluate(time);
//        lightSource.intensity = intensity;

//        GameObject go = lightSource.gameObject;
//        if (lightSource.intensity == 0 && go.activeInHierarchy)
//            go.SetActive(false);
//        else if (lightSource.intensity > 0 && !go.activeInHierarchy)
//            go.SetActive(true);
//    }
//}