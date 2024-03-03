using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldSyetem : MonoBehaviour
{
    public TextMeshProUGUI GoldText;
    public int Gold { get { return gold; } set { gold = value; } }
    private int gold;

    private void Start()
            
    {
        gold = 50000;

    }
    void Update()
    {
        
        GoldText.text = Gold.ToString();
    }
}
