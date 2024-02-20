using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolumeController : MonoBehaviour
{
    public AudioMixerGroup masterMixerGroup;
    public Slider masterVolumeSlider;

    // ���ú� �ּڰ��� �ִ� ����
    private const float minVolumeDB = -80f;
    private const float maxVolumeDB = 0f;

    private void Start()
    {
        // �ʱ�ȭ�� �� ������ ���� �����̴� ����
        SetMasterVolume(masterVolumeSlider.value);
    }

    public void SetMasterVolume(float volume)
    {
        // �����̴� ��(0~1)�� ���ú� ������ ��ȯ
        float volumeDB = Mathf.Lerp(minVolumeDB, maxVolumeDB, volume);
        // ��ȯ�� ���ú� ������ ������ ���� ����
        masterMixerGroup.audioMixer.SetFloat("MasterVolume", volumeDB);
    }
}
