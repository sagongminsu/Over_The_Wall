using UnityEngine;

[CreateAssetMenu(fileName = "SpeakObject", menuName = "Speak/SpeakObject")]
public class SpeakObject : ScriptableObject
{
    [TextArea(3, 10)]
    public string[] speakLines; 

    public Response[] responses; 
}

[System.Serializable]
public class Response
{
    public string responseText; 
    public SpeakObject nextSpeak; 
}