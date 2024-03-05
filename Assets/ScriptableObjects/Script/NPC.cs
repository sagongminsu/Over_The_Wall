using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;

public class NPC : MonoBehaviour, IInteraction
{
    public string interactPrompt = "대화하기";

    public float detectionRange = 5f;
    public GameObject player;
    public QuestData quest;

    //public GameObject UI;
    public GameObject Dialogue;

    public TextMeshProUGUI DialogueText;
    //public TextMeshProUGUI title;
    //public TextMeshProUGUI description;
    //public TextMeshProUGUI required;

    private int currentDialogueIndex = 0;
    private int currentOnGoingIndex = 0;
    private int currentCompleteIndex = 0;
    private int currentCompletedIndex = 0;

    private bool IsDialouge;

    private Inventory inventory;

    private bool playerInRange = false;

    // NavMeshAgent 추가
    private NavMeshAgent agent;
    public Transform targetLocation;
    private bool isMovingToTarget = false;
    public Transform secondTargetLocation;

    // 이동 완료 상태를 추적하는 변수들
    private bool isFirstLocationReached = false;
    private bool isSecondLocationReached = false;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogError("플레이어를 찾을 수 없습니다.");
        }
        inventory = FindObjectOfType<Inventory>();
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent 컴포넌트가 이 GameObject에 없습니다.");
        }
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= detectionRange)
        {
            if (!playerInRange)
            {
                playerInRange = true;
            }
        }
        else
        {
            if (playerInRange)
            {
                playerInRange = false;
            }
        }
        if (isMovingToTarget && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            // 목적지에 도착했으면 퀘스트를 완료 상태로 표시
            quest.isCompleted = true;
            isMovingToTarget = false; // 이동을 마쳤으므로 이동 상태를 false로 설정
        }
        if (isMovingToTarget && !agent.pathPending &&
            agent.remainingDistance <= agent.stoppingDistance && !isFirstLocationReached)
        {
            // 첫 번째 목적지에 도착했으므로 isCompleted를 true로 설정
            quest.isCompleted = true;
            isMovingToTarget = false;
            isFirstLocationReached = true;
        }
    }

    #region dialogue
    private void StartDialogue()
    {
        ShowCurrentDialogue();
    }

    private void EndDialogue()
    {
        DialougeSetFlase();
        if (!isFirstLocationReached)
        {
            if (targetLocation != null)
            {
                agent.SetDestination(targetLocation.position);
                isMovingToTarget = true;
                isFirstLocationReached = true;
            }
            else
            {
                Debug.LogError("NPC가 이동할 첫 번째 목표 위치가 지정안됨");
            }
        }
        // isCompleted 상태이고 두 번째 목적지로 이동하는 조건을 체크
        else if (quest.isCompleted && !isSecondLocationReached)
        {
            if (secondTargetLocation != null)
            {
                agent.SetDestination(secondTargetLocation.position);
                isSecondLocationReached = true;
            }
            else
            {
                Debug.LogError("NPC가 이동할 두 번째 목표 위치가 지정안됨");
            }
        }
        if (quest.isCompleted && isFirstLocationReached && !isSecondLocationReached)
        {
            // 두 번째 목적지로 이동
            if (secondTargetLocation != null)
            {
                agent.SetDestination(secondTargetLocation.position);
                isSecondLocationReached = true; // 두 번째 목적지로 이동 시작
            }
            else
            {
                Debug.LogError("NPC가 이동할 두 번째 목표 위치가 지정안됨");
            }
        }
    }


    private void ShowCurrentDialogue()
    {
        DialogueSetTrue();
        if (!quest.onGoing)
        {
            if (currentDialogueIndex < quest.Dialouge.Length)
            {
                DialogueText.text = quest.Dialouge[currentDialogueIndex];
            }
        }
        else if (!quest.isCompleted)
        {
            if (!HasRequiredItems())
            {
                if (currentOnGoingIndex < quest.OnGoing.Length)
                {
                    DialogueText.text = quest.OnGoing[currentOnGoingIndex];
                }
            }
            else if (HasRequiredItems())
            {
                if (currentCompleteIndex < quest.Complete.Length)
                {
                    DialogueText.text = quest.Complete[currentCompleteIndex];
                }
            }

        }

        else if (quest.isCompleted)
        {
            if (currentCompletedIndex < quest.Completed.Length)
            {
                DialogueText.text = quest.Completed[currentCompletedIndex];
            }
        }

    }

    #endregion

    #region quest
    //public void SetQuest()
    //{
    //    title.text = quest.questTitle;
    //    description.text = quest.questDescription;


    //    string concatenatedText = "";

    //    foreach (RequiredResource resource in quest.requiredResource)
    //    {
    //        concatenatedText += $"{resource.resourceType}: {resource.requiredAmount}\n";
    //    }

    //    required.text = concatenatedText;
    //}

    #endregion

    private void QuestOngoing()
    {
        quest.onGoing = true;
    }

    private void QuestComplete()
    {
        foreach (RequiredResource requiredResource in quest.requiredResource)
        {
            ItemData_ item = requiredResource.item;
            int requiredAmount = requiredResource.requiredAmount;

            inventory.RemoveItem(item, requiredAmount);
        }
    }

    #region Dialogue
    private void DialogueSetTrue()
    {
        IsDialouge = true;
        Dialogue.SetActive(true);
    }

    private void DialougeSetFlase()
    {
        IsDialouge = false;
        Dialogue.SetActive(false);
    }
    #endregion

    private bool HasRequiredItems()
    {
        foreach (RequiredResource requiredResource in quest.requiredResource)
        {
            ItemData_ item = requiredResource.item;
            int requiredAmount = requiredResource.requiredAmount;

            bool hasItem = inventory.CheckQuestCompletion(item, requiredAmount);
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
            if (IsDialouge)
            {
                if (!quest.onGoing && !quest.isCompleted)
                {
                    currentDialogueIndex++;
                    ShowCurrentDialogue();

                    if (currentDialogueIndex >= quest.Dialouge.Length)
                    {
                        currentDialogueIndex = 0;
                        EndDialogue();
                        //SetQuest();
                        QuestOngoing();
                        //UI.SetActive(true);
                    }
                }
                else if (!quest.isCompleted)
                {
                    if (!HasRequiredItems())
                    {
                        currentOnGoingIndex++;
                        ShowCurrentDialogue();

                        if (currentOnGoingIndex >= quest.OnGoing.Length)
                        {
                            currentOnGoingIndex = 0;
                            EndDialogue();
                        }
                    }
                    else if (HasRequiredItems())
                    {
                        currentCompleteIndex++;
                        ShowCurrentDialogue();

                        if (currentCompleteIndex >= quest.Complete.Length)
                        {
                            currentCompleteIndex = 0;
                            EndDialogue();
                            QuestComplete();
                        }
                    }
                }
                else if (quest.isCompleted)
                {
                    currentCompletedIndex++;
                    ShowCurrentDialogue();

                    if (currentCompletedIndex >= quest.Completed.Length)
                    {
                        currentCompletedIndex = 0;
                        EndDialogue();
                    }
                }
            }
            else
            {
                StartDialogue();
                currentDialogueIndex = 0;
                currentOnGoingIndex = 0;
                currentCompleteIndex = 0;
                currentCompletedIndex = 0;
            }

        }
        if (isFirstLocationReached && quest.isCompleted && !isSecondLocationReached)
        {
            agent.SetDestination(secondTargetLocation.position);
            isMovingToTarget = true;
            isSecondLocationReached = true; // 두 번째 이동 시작
        }
    }
}
