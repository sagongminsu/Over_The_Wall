using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour
{
    [Header("spotlight")]
    public Light spotlight;
    public AnimationCurve SpotLightIntensity;
    public DayNightCycle dayNightCycle; // DayNightCycle ����

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
        // ���⿡ �ʿ��� �߰� ������ �߰��� �� �ֽ��ϴ�.
    }
}
