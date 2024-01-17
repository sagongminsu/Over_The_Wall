using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLight : MonoBehaviour
{
    [Header("LampLight")]
    public Light Lamplight;
    public AnimationCurve  LampLightIntensity;
    public DayNightCycle dayNightCycle; // DayNightCycle ����

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
        // ���⿡ �ʿ��� �߰� ������ �߰��� �� �ֽ��ϴ�.
    }
}
