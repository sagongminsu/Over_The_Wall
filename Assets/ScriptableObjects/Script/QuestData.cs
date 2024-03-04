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


[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest System/Quest")]
public class QuestData : ScriptableObject
{
    [Header("Info")]
    public string questTitle;
    public string questDescription;
    public bool onGoing;
    public bool isCompleted;

    public RequiredResource[] requiredResource;

    [Header("Dialouge")]
    public string[] Dialouge;
    public string[] OnGoing;
    public string[] Complete;
    public string[] Completed;

}
