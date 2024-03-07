using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GoldManager : MonoBehaviour
{
    public TextMeshProUGUI GoldText;
    public int Gold { get { return gold; } set { gold = value; } }
    private int gold;
    public bool isMining;
    public static GoldManager instance;
    void Awake()
    {
        if (instance == null)
        {

            instance = this;
            

        }
    }

    private void Start()

    {
        gold = 50000;

    }
    void Update()
    {

        GoldText.text = Gold.ToString();
    }
}
