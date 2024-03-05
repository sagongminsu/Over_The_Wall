using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoneTiming : MonoBehaviour
{
    public GameObject Stone;
    public GameObject Quarry;
    public TextMeshProUGUI Gold;
    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    [SerializeField] Animator StoneHit = null;

    public GoldManager goldManager;

    public string hit = "Hit";

    public int totalGold;
    public int addGold;
    private int inputCount = 0;
    

    Vector2[] timingBoxs = null;
    void Start()
    {
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
            
        }
        if (inputCount == 5)
        {
            Quarry.SetActive(false);
            SetScore();
        }
        Gold.text = totalGold.ToString();
        Debug.Log(totalGold);
    }
    public void CheckTiming()
    {
        float StonePosX = Stone.transform.localPosition.x;
        for (int x = 0; x < timingBoxs.Length; x++)
        {
            if (timingBoxs[x].x <= StonePosX && StonePosX <= timingBoxs[x].y)
            {
               
                StoneHitEffect();
                if (x == 0)
                {
                    addGold = 200;
                }
                else if (x == 1)
                {
                    addGold = 200;
                }
                else if (x == 2)
                {
                    addGold = 100;
                }
                totalGold += addGold;
            }
            else
            {
                Debug.Log("Fail");
            }
            
        }
    }
    public void StoneHitEffect()
    {
        StoneHit.SetTrigger(hit);
    }
    public void SetScore()
    {
        goldManager.Gold += totalGold;
    }
}
