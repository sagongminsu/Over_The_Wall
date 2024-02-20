using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip[] doorSounds = new AudioClip[3]; // ���� ���带 �����ϴ� �迭
    public AudioClip[] bgmTracks; // BGM Ʈ���� �����ϴ� �迭

    private AudioSource audioSource;
    private AudioSource bgmSource;

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
        }

        audioSource = GetComponent<AudioSource>();

        // BGM�� ���� AudioSource �߰�
        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.loop = true;
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

    public void PlayBGM(int trackIndex)
    {
        if (trackIndex >= 0 && trackIndex < bgmTracks.Length && bgmTracks[trackIndex] != null)
        {
            bgmSource.clip = bgmTracks[trackIndex];
            bgmSource.Play();
        }
        else
        {
            Debug.LogWarning("Requested BGM track is missing or invalid!");
        }
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }
}
