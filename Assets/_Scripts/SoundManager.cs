using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject soundManagerObject = new GameObject("SoundManager");
                instance = soundManagerObject.AddComponent<SoundManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlaySound(AudioClip soundClip)
    {
        // ���带 ����ϴ� �ڵ带 ���⿡ �߰��մϴ�.
    }

    // ���带 �����ϴ� �޼���
    public void StopSound(AudioClip soundClip)
    {
        // ���带 �����ϴ� �ڵ带 ���⿡ �߰��մϴ�.
    }

    // ���⿡ �ʿ��� �ٸ� ���� ���� �޼��带 �߰��մϴ�.
}
