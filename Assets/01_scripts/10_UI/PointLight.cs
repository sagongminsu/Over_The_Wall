using UnityEngine;

public class PointLight : MonoBehaviour
{
    public Color lightColor = Color.blue;
    public float lightIntensity = 5f;

    void Start()
    {
        CreatePointLightPillar();
    }

    void CreatePointLightPillar()
    {
        // 기둥을 현재 오브젝트의 위치에 생성
        GameObject pillar = new GameObject("PointLightPillar");
        pillar.transform.position = transform.position;

        Light pointLight = pillar.AddComponent<Light>();
        pointLight.type = LightType.Point;
        pointLight.color = lightColor;
        pointLight.intensity = lightIntensity;
    }
}
