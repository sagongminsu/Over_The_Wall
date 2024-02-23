using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    gameManager gameManager;

    public Transform playerTransform;
    public Transform teleportDestination;
    public Collider teleportArea;
    public GameObject WarningMessage;
    public TextMeshProUGUI Text;

    public float teleportDelay = 10f;

    private float timer = 0f;
    private bool teleportActivated = false;
    private void Awake()
    {
        gameManager = gameManager.I;
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
                timer += Time.deltaTime;
                if (timer >= teleportDelay)
                {
                    teleportActivated = true;
                    TeleportPlayer();     
                }
            }
            else
            {
                ResetTeleportTimer();
                DeactivateWarningMessage();
            }
        }
        else
        {
            ResetTeleportTimer();
            DeactivateWarningMessage();
        }
    }

    private bool IsTimeLimitExceeded()
    {
        return gameManager.CheckTime(6, 23);
    }
    private bool IsPlayerInsideTeleportArea()
    {
        return !teleportArea.bounds.Contains(playerTransform.position);
    }

    private void ResetTeleportTimer()
    {
        timer = 0f;
        teleportActivated = false;
    }

    private void TeleportPlayer()
    {
        playerTransform.position = teleportDestination.position;
        ResetTeleportTimer();
    }

    private void ActivateWarningMessage()
    {
        if (gameManager.CheckTime(22, 23))
        {
            WarningMessage.SetActive(true);

            Text.text = "취침 시간입니다. 어서 돌아가세요!";
        }
    }

    private void DeactivateWarningMessage()
    {
        WarningMessage.SetActive(false);
    }


}
