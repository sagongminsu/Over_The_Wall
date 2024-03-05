using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{

}

[Serializable]
public class RequiredResource
{
    public ItemData_ item;
    public ResourceType resourceType;
    public int requiredAmount;
}

[Serializable]
public class QuestDialogue
{
    public string[] BeforeStart;
    public string[] OnGoing;
    public string[] OnComplete;
    public string[] AfterComplete;
}


[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest System/Quest")]
public class QuestData : ScriptableObject
{
    [Header("Info")]
    public string questID;
    public string questTitle;
    public string questDescription;
    public bool onGoing;
    public bool isCompleted;

    [Header("RequiredResource")]
    public RequiredResource[] requiredResource;

    [Header("Dialouge")]
    public QuestDialogue questDialogue;

    // 추가: 퀘스트 클리어 함수
    public void CompleteQuest()
    {
        isCompleted = true;
        // 다른 클리어에 관련된 동작 수행
    }
}