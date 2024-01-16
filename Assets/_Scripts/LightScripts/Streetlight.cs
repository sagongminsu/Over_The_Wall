using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streetlight : MonoBehaviour
{
    [Header("StreetLight")]
    public Light streetlight;
    public AnimationCurve streetLightIntensity;
    public DayNightCycle dayNightCycle; // DayNightCycle 참조

    private void Update()
    {
        if (dayNightCycle != null)
        {
            UpdateStreetLighting(dayNightCycle.GetCurrentTime());
        }
    }

    private void UpdateStreetLighting(float currentTime)
    {
        float intensity = streetLightIntensity.Evaluate(currentTime);
        streetlight.intensity = intensity;
        // 여기에 필요한 추가 로직을 추가할 수 있습니다.
    }
}
