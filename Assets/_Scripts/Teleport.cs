using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    gameManager gameManager;

    public Transform playerTransform;
    public Transform teleportDestination;
    public Collider teleportArea;
    public GameObject WarningMessage;
    public TextMeshProUGUI Text;

    public float teleportDelay = 1.0f;

    private float timer = 0f;
    private bool teleportActivated = false;
    private void Awake()
    {
        gameManager = gameManager.I;
    }

    private void Start()
    {
        WarningMessage.SetActive(false);
    }

    void Update()
    {
        DoTeleport();
    }

    private void DoTeleport()
    {
        if (!IsTimeLimitExceeded())
        {
            
            if (!IsPlayerInsideTeleportArea())
            {
                ActivateWarningMessage();
                if (gameManager.CheckTime(06, 22) == false)
                {
                    timer += Time.deltaTime;
                    if (timer >= teleportDelay)
                    {
                        teleportActivated = true;
                        TeleportPlayer();
                    }
                }
            }
            else
            {
                ResetTeleportTimer();
                DeactivateWarningMessage();
                WarningMessage.SetActive(false);
            }
        }
        else
        {
            ResetTeleportTimer();
            DeactivateWarningMessage();
            WarningMessage.SetActive(false);
        }
    }

    private bool IsTimeLimitExceeded()
    {
        return gameManager.CheckTime(6, 21);
    }
    private bool IsPlayerInsideTeleportArea()
    {
        return teleportArea.bounds.Contains(playerTransform.position);
    }

    private void ResetTeleportTimer()
    {
        timer = 0f;
        teleportActivated = false;
    }

    private void TeleportPlayer()
    {
        Time.timeScale = 0.0f;
        playerTransform.position = teleportDestination.position;
        ResetTeleportTimer();
        Time.timeScale = 1.0f;
    }

    private void ActivateWarningMessage()
    {
        if (gameManager.CheckTime(21, 22))
        {
            WarningMessage.SetActive(true);

            Text.text = "취침 시간입니다. 어서 돌아가세요!";
        }
        else
        {
            Text.text = "시간내에 복귀하지 못했습니다. 강제로 귀환합니다.";
        }
    }

    private void DeactivateWarningMessage()
    {
        WarningMessage.SetActive(false);
    }
}
