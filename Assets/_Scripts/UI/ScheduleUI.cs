using TMPro;
using UnityEngine;

public class ScheduleUI : MonoBehaviour
{
    public GameObject targetObject;
    public TMP_Text textField;
    public string defaultText = "해야할 일\n1. 죄수npc와 대화\n2. 갱단보스와 대화\n3. 점심식사하기\n4. 숨겨진 열쇠찾기\n5. 자정까지 방으로 돌아가서 잠자기"; // 기본 텍스트
    public string alternativeText = "Alternative Text";

    void Start()
    {
        Day0Text(defaultText);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (targetObject != null)
            {
                targetObject.SetActive(!targetObject.activeSelf);
            }
        }
    }
    public void Day1Text(bool condition)
    {
        if (condition)
        {
            Day0Text(alternativeText);
        }
        else
        {
            Day0Text(defaultText);
        }
    }

    void Day0Text(string text)
    {
        if (textField != null)
        {
            textField.text = text;
        }
        else
        {
            Debug.LogWarning("TMP Text field is not assigned!");
        }
    }
    public void UpdateDay0TextForQuest(int questNumber)
    {
        Debug.Log("퀘스트목록 업데이트");
        string updatedText = defaultText;

        switch (questNumber)
        {
            case 1:
                updatedText = defaultText.Replace("1. 죄수npc와 대화", "<s>1. 죄수npc와 대화</s>");
                break;
            case 2:
                updatedText = defaultText.Replace("2. 갱단보스와 대화", "<s>2. 갱단보스와 대화</s>");
                break;
            case 3:
                updatedText = defaultText.Replace("3. 점심식사하기", "<s>3. 점심식사하기</s>");
                break;
            case 4:
                updatedText = defaultText.Replace("4. 숨겨진 열쇠찾기", "<s>4. 숨겨진 열쇠찾기</s>");
                break;
            case 5:
                updatedText = defaultText.Replace("5. 자정까지 방으로 돌아가서 잠자기", "<s>5. 자정까지 방으로 돌아가서 잠자기</s>");
                break;
            default:
                Debug.LogWarning("Invalid quest number!");
                break;
        }

        Day0Text(updatedText);
    }
}
