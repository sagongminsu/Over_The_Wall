using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip[] doorSounds = new AudioClip[3]; // ���� ���带 �����ϴ� �迭
    public AudioClip[] bgmTracks; // BGM Ʈ���� �����ϴ� �迭

    public AudioSource audioSource;
    public AudioSource bgmSource;

    private int currentBGMIndex = 0; // ���� ��� ���� BGM �ε���

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

        bgmSource.loop = false; // BGM�� �ݺ� ������� �ʵ��� ����
    }

    private void Start()
    {
        // ���� ���� �� ù ��° BGM ���
        PlayNextBGM();
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

        // ���� BGM �ε��� ����
        currentBGMIndex = (currentBGMIndex + 1) % bgmTracks.Length;

        // ���� BGM ���
        bgmSource.clip = bgmTracks[currentBGMIndex];
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    // BGM Ʈ���� ������ ���� BGM Ʈ�� ���
    private void OnBGMTrackEnd()
    {
        PlayNextBGM();
    }

    // Update �޼��忡�� BGM ��� ���¸� �����Ͽ� ������ OnBGMTrackEnd �޼��� ȣ��
    private void Update()
    {
        if (!bgmSource.isPlaying)
        {
            OnBGMTrackEnd();
        }
    }
}
