using TMPro;
using UnityEngine;

public class ScheduleUI : MonoBehaviour
{
    public GameObject targetObject;
    public TMP_Text textField;
    public string defaultText = "�ؾ��� ��\n1. �˼�npc�� ��ȭ\n2. ���ܺ����� ��ȭ\n3. ���ɽĻ��ϱ�\n4. ������ ����ã��\n5. �������� ������ ���ư��� ���ڱ�"; // �⺻ �ؽ�Ʈ
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
        Debug.Log("����Ʈ��� ������Ʈ");
        string updatedText = defaultText;

        switch (questNumber)
        {
            case 1:
                updatedText = defaultText.Replace("1. �˼�npc�� ��ȭ", "<s>1. �˼�npc�� ��ȭ</s>");
                break;
            case 2:
                updatedText = defaultText.Replace("2. ���ܺ����� ��ȭ", "<s>2. ���ܺ����� ��ȭ</s>");
                break;
            case 3:
                updatedText = defaultText.Replace("3. ���ɽĻ��ϱ�", "<s>3. ���ɽĻ��ϱ�</s>");
                break;
            case 4:
                updatedText = defaultText.Replace("4. ������ ����ã��", "<s>4. ������ ����ã��</s>");
                break;
            case 5:
                updatedText = defaultText.Replace("5. �������� ������ ���ư��� ���ڱ�", "<s>5. �������� ������ ���ư��� ���ڱ�</s>");
                break;
            default:
                Debug.LogWarning("Invalid quest number!");
                break;
        }

        Day0Text(updatedText);
    }
}
