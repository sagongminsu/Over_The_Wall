using System.Text;
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

}
