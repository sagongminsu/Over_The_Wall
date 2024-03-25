using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenUI : MonoBehaviour
{
    public GameObject Inventory;
    gameManager gameManager;

    private void Awake()
    {
        Inventory = GameObject.Find("Inventory");
        gameManager = gameManager.I;
    }

    private void Start()
    {
        Inventory.SetActive(false);
        gameManager.isPause = CheckActive();
    }

    public void ActiveUI(bool IsBool)
    {
        Inventory.SetActive(IsBool);
        gameManager.Open = CheckActive();
    }

    public bool CheckActive()
    {
        return Inventory.activeSelf;
    }
}
