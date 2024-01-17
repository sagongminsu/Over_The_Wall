using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLight : MonoBehaviour
{
    [Header("LampLight")]
    public Light Lamplight;
    public AnimationCurve  LampLightIntensity;
    public DayNightCycle dayNightCycle; // DayNightCycle 참조

    private void Update()
    {
        if (dayNightCycle != null)
        {
            UpdateLamplighting(dayNightCycle.GetCurrentTime());
        }
    }

    private void UpdateLamplighting(float currentTime)
    {
        float intensity =  LampLightIntensity.Evaluate(currentTime);
        Lamplight.intensity = intensity;
        // 여기에 필요한 추가 로직을 추가할 수 있습니다.
    }
}
