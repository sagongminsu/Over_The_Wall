using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public GameObject PauseCanvas;
    gameManager gameManager;

    private void Awake()
    {
        PauseCanvas = GameObject.Find("PauseCanvas");
        gameManager = gameManager.I;
    }

    private void Start()
    {
        PauseCanvas.SetActive(false);
        gameManager.isPause = CheckActive();
    }

    public void ActiveUI(bool IsBool)
    {
        PauseCanvas.SetActive(IsBool);
        gameManager.isPause = CheckActive();
    }

    public bool CheckActive()
    {
        return PauseCanvas.activeSelf;
    }

}
