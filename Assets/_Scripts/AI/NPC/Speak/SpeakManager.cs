using UnityEngine;
using UnityEngine.UI;

public class SpeakManager : MonoBehaviour
{
    public GameObject speakPanel;
    public Text speakText;
    public Button[] responseButtons;

    private int currentLineIndex = 0;
    private SpeakObject currentSpeak;

    public void StartSpeak(SpeakObject speakObject)
    {
        currentSpeak = speakObject;
        speakPanel.SetActive(true);
        currentLineIndex = 0;
        ShowSpeak();
    }

    public void ShowSpeak()
    {
        if (currentLineIndex < currentSpeak.speakLines.Length)
        {
            speakText.text = currentSpeak.speakLines[currentLineIndex];
            currentLineIndex++;
        }
        else
        {
            ShowResponses();
        }
    }

    private void ShowResponses()
    {
        if (currentSpeak.responses != null && currentSpeak.responses.Length > 0)
        {
            for (int i = 0; i < currentSpeak.responses.Length; i++)
            {
                responseButtons[i].gameObject.SetActive(true);
                responseButtons[i].GetComponentInChildren<Text>().text = currentSpeak.responses[i].responseText;
                int responseIndex = i;
                responseButtons[i].onClick.AddListener(() => OnResponseClicked(responseIndex));
            }
        }
        else
        {
            EndSpeak();
        }
    }

    public void OnResponseClicked(int index)
    {
        StartSpeak(currentSpeak.responses[index].nextSpeak);
    }

    public void EndSpeak()
    {
        speakPanel.SetActive(false);
    }

    // UI 버튼에 연결된 메서드로, 다음 대화 줄을 표시합니다.
    public void OnNextLineClicked()
    {
        ShowSpeak();
    }
}