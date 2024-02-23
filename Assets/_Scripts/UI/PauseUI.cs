using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public GameObject PauseCanvas;

    private void Awake()
    {
        PauseCanvas = GameObject.Find("PauseCanvas");
    }

    private void Start()
    {
        PauseCanvas.SetActive(false);
    }
    public void ActiveUI(bool IsBool)
    {
        PauseCanvas.SetActive(IsBool);
    }

    public bool CheckActive()
    {
        return PauseCanvas.activeSelf;
    }
}
