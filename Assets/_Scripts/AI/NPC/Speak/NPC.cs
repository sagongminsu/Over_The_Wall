using UnityEngine;

public class NPC : MonoBehaviour
{
    public SpeakObject startSpeak;

    public void OnTalk()
    {
        FindObjectOfType<SpeakManager>().StartSpeak(startSpeak);
    }
}
