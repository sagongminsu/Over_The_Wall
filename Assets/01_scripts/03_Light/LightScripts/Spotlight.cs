using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour
{
    [Header("spotlight")]
    public Light spotlight;
    public AnimationCurve SpotLightIntensity;
    public DayNightCycle dayNightCycle; // DayNightCycle 참조

    private void Update()
    {
        if (dayNightCycle != null)
        {
            UpdateSpotLighting(dayNightCycle.GetCurrentTime());
        }
    }

    private void UpdateSpotLighting(float currentTime)
    {
        float intensity = SpotLightIntensity.Evaluate(currentTime);
        spotlight.intensity = intensity;
        // 여기에 필요한 추가 로직을 추가할 수 있습니다.
    }
}
