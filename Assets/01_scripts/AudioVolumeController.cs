using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolumeController : MonoBehaviour
{
    public AudioMixerGroup masterMixerGroup;
    public Slider masterVolumeSlider;

    // 데시벨 최솟값과 최댓값 정의
    private const float minVolumeDB = -80f;
    private const float maxVolumeDB = 0f;

    private void Start()
    {
        // 초기화할 때 마스터 볼륨 슬라이더 설정
        SetMasterVolume(masterVolumeSlider.value);
    }

    public void SetMasterVolume(float volume)
    {
        // 슬라이더 값(0~1)을 데시벨 값으로 변환
        float volumeDB = Mathf.Lerp(minVolumeDB, maxVolumeDB, volume);
        // 변환된 데시벨 값으로 마스터 볼륨 설정
        masterMixerGroup.audioMixer.SetFloat("MasterVolume", volumeDB);
    }
}
