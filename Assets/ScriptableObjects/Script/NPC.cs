using System;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour, IInteraction
{
    public QuestManager questManager;

    public string interactPrompt = "대화하기";
    public float detectionRange = 5f;
    public GameObject player;
    public QuestData quest;
    public GameObject dialogueUI;
    public TextMeshProUGUI dialogueText;

    private int currentDialogueIndex = 0;
    private bool isDialogueActive;

    private Inventory inventory;
    private bool playerInRange = false;

    private NavMeshAgent agent; 
    public Transform targetLocation; 
    public Transform secondTargetLocation; 

    private void Awake()
    {
        questManager = QuestManager.instance;
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogError("플레이어를 찾을 수 없습니다.");
        }
        inventory = FindObjectOfType<Inventory>();
        // Initialize NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component missing on this GameObject.");
        }
    }

    private void Update()
    {
        UpdatePlayerInRange();
    }
    private void MoveToTarget(Transform target)
    {
        if (agent != null && target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    private void UpdatePlayerInRange()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= detectionRange && !playerInRange)
        {
            playerInRange = true;
        }
        else if (distance > detectionRange && playerInRange)
        {
            playerInRange = false;
            EndDialogue();
            ResetDialogueIndices();
        }
    }

    #region Dialogue

    private void StartDialogue()
    {
        ShowCurrentDialogue();
    }

    private void EndDialogue()
    {
        SetDialogueActive(false);
    }

    private void ShowCurrentDialogue()
    {
        SetDialogueActive(true);

        if (!quest.onGoing)
        {
            DisplayDialogue(quest.questDialogue.BeforeStart);
        }
        else if (!quest.isCompleted)
        {
            if (!HasRequiredItems())
            {
                DisplayDialogue(quest.questDialogue.OnGoing);
            }
            else
            {
                DisplayDialogue(quest.questDialogue.OnComplete);
            }
        }
        else if (quest.isCompleted)
        {
            DisplayDialogue(quest.questDialogue.AfterComplete);
        }
    }

    private void DisplayDialogue(string[] dialogueArray)
    {
        if (currentDialogueIndex < dialogueArray.Length)
        {
            dialogueText.text = dialogueArray[currentDialogueIndex];
        }
    }

    #endregion

    #region Quest

    private void QuestOngoing()
    {
        quest.onGoing = true;
        
        MoveToTarget(targetLocation);
    }


    private void QuestComplete()
    {
        foreach (RequiredResource requiredResource in quest.requiredResource)
        {
            inventory.RemoveItem(requiredResource.item, requiredResource.requiredAmount);
        }
        MoveToTarget(secondTargetLocation);
    }

    #endregion

    #region Dialogue Control

    private void SetDialogueActive(bool active)
    {
        isDialogueActive = active;
        dialogueUI.SetActive(active);
    }

    #endregion

    private bool HasRequiredItems()
    {
        foreach (RequiredResource requiredResource in quest.requiredResource)
        {
            bool hasItem = inventory.CheckQuestCompletion(requiredResource.item, requiredResource.requiredAmount);
            if (!hasItem)
            {
                return false;
            }
        }
        return true;
    }

    public string GetInteractPrompt()
    {
        return interactPrompt;
    }

    public void OnInteract()
    {
        if (playerInRange)
        {
            if (isDialogueActive)
            {
                HandleDialogue();
            }
            else
            {
                StartDialogue();
                ResetDialogueIndices();
            }
        }
    }

    private void HandleDialogue()
    {
        if (!quest.onGoing && !quest.isCompleted)
        {
            DisplayNextDialogue(quest.questDialogue.BeforeStart, EndDialogue, QuestOngoing);
        }
        else if (!quest.isCompleted)
        {
            if (!HasRequiredItems())
            {
                DisplayNextDialogue(quest.questDialogue.OnGoing, EndDialogue);
            }
            else
            {
                DisplayNextDialogue(quest.questDialogue.OnComplete, EndDialogue, QuestComplete);
            }
        }
        else if (quest.isCompleted)
        {
            DisplayNextDialogue(quest.questDialogue.AfterComplete, EndDialogue);
        }
    }

    private void DisplayNextDialogue(string[] dialogueArray, Action onEnd, Action onNext = null)
    {
        currentDialogueIndex++;
        DisplayDialogue(dialogueArray);

        if (currentDialogueIndex >= dialogueArray.Length)
        {
            currentDialogueIndex = 0;
            onEnd?.Invoke();
            onNext?.Invoke();
        }
    }

    private void ResetDialogueIndices()
    {
        currentDialogueIndex = 0;
    }

}