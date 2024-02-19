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
        // 사운드를 재생하는 코드를 여기에 추가합니다.
    }

    // 사운드를 정지하는 메서드
    public void StopSound(AudioClip soundClip)
    {
        // 사운드를 정지하는 코드를 여기에 추가합니다.
    }

    // 여기에 필요한 다른 사운드 관리 메서드를 추가합니다.
}
