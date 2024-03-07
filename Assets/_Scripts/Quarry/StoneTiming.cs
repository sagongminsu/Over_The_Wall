using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoneTiming : MonoBehaviour
{
    public GameObject Stone;
    public GameObject Quarry;
    public TextMeshProUGUI Gold;
    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
 

    private Effect effect;
    private GoldManager goldManager;

    public string hit = "Hit";

    public int totalGold;
    public int addGold;
    public int inputCount = 0;
    

    Vector2[] timingBoxs = null;
    void Start()
    {
        goldManager = GoldManager.instance;
        effect = GetComponent<Effect>();

        Quarry.SetActive(false);
        timingBoxs = new Vector2[timingRect.Length];
        for(int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2,
                              Center.localPosition.x + timingRect[i].rect.width / 2);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inputCount++;
            CheckTiming();
            goldManager.isMining = true;

        }
        if (inputCount == 5)
        {
            
            Quarry.SetActive(false);
            SetScore();
            totalGold = 0;
            goldManager.isMining = false;
            

        }
       
        Gold.text = totalGold.ToString();
    }
    public void CheckTiming()
    {
        float StonePosX = Stone.transform.localPosition.x;
        for (int x = 0; x < timingBoxs.Length; x++)
        {
            if (timingBoxs[x].x <= StonePosX && StonePosX <= timingBoxs[x].y)
            {
               
                effect.StoneHitEffect();
                effect.JudgmentEffect(x);
                TakeGold(x);
                totalGold += addGold;
                return;
            }
            else
            {
                effect.JudgmentEffect(3);
            }
            
        }
    }
   
    public void SetScore()
    {
        goldManager.Gold += totalGold;
    }
    public void TakeGold(int gold)
    {
        if (gold == 0)
        {
            addGold = 200;
        }
        else if (gold == 1)
        {
            addGold = 200;
        }
        else if (gold == 2)
        {
            addGold = 100;
        }
        else
        {
            addGold = 0;
        }
    }
    
}
