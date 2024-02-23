using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioMixer masterMixer;
    public Slider audioSlider;

    public AudioClip[] doorSounds = new AudioClip[3]; // 도어 사운드를 저장하는 배열
    public AudioClip[] bgmTracks; // BGM 트랙을 저장하는 배열
    public AudioSource walkSoundSource; // 걷는 소리 AudioSource

    public AudioSource audioSource;
    public AudioSource bgmSource;

    private int currentBGMIndex = 0; // 현재 재생 중인 BGM 인덱스

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        bgmSource.loop = false; // BGM은 반복 재생하지 않도록 설정
    }

    private void Start()
    {
        // 게임 시작 시 첫 번째 BGM 재생
        PlayNextBGM();
    }
    public void AudioControl()
    {
        float sound = audioSlider.value;

        if (sound == -40f)
        {
            masterMixer.SetFloat("Master", -80f);
        }
        else masterMixer.SetFloat("Master", sound);
    }

    public void PlayDoorSound(int index)
    {
        if (index >= 0 && index < doorSounds.Length && doorSounds[index] != null)
        {
            audioSource.PlayOneShot(doorSounds[index]);
        }
        else
        {
            Debug.LogWarning("Requested door sound is missing or invalid!");
        }
    }

    public void PlayNextBGM()
    {
        if (bgmTracks.Length == 0)
        {
            Debug.LogWarning("No BGM tracks available!");
            return;
        }

        // 다음 BGM 인덱스 설정
        currentBGMIndex = (currentBGMIndex + 1) % bgmTracks.Length;

        // 다음 BGM 재생
        bgmSource.clip = bgmTracks[currentBGMIndex];
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    // BGM 트랙이 끝나면 다음 BGM 트랙 재생
    private void OnBGMTrackEnd()
    {
        PlayNextBGM();
    }

    // Update 메서드에서 BGM 재생 상태를 감지하여 끝나면 OnBGMTrackEnd 메서드 호출
    private void Update()
    {
        if (!bgmSource.isPlaying)
        {
            OnBGMTrackEnd();
        }
    }

    // 걷는 소리 재생
    public void PlayWalkSound(float pitch)
    {
        if (walkSoundSource != null)
        {
            walkSoundSource.pitch = pitch; // Pitch 설정
            walkSoundSource.loop = true; // 루프 설정
            walkSoundSource.Play();
        }
        else
        {
            Debug.LogWarning("Walk sound source is missing!");
        }
    }

    // 걷는 소리 중지
    public void StopWalkSound()
    {
        if (walkSoundSource != null && walkSoundSource.isPlaying)
        {
            walkSoundSource.Stop();
            walkSoundSource.loop = false; // 루프 중지
        }
    }
}
