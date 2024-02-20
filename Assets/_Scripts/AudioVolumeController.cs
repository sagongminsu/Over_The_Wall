using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolumeController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider masterVolumeSlider;
    public Slider bgmVolumeSlider;
    public Slider sfxVolumeSlider;

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGMVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }
}
