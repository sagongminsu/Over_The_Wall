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
    [SerializeField] Animator judgementAnimator = null;
    [SerializeField] UnityEngine.UI.Image judgemenImage = null;
    [SerializeField] Sprite[] judementSprite = null;

    private GoldManager goldManager;
    public gameManager gameManager;
   

    public string hit = "Hit";

    public int totalGold;
    public int addGold;
    public int inputCount = 0;
    

    Vector2[] timingBoxs = null;
    void Start()
    {
        goldManager = GoldManager.instance;
        gameManager = gameManager.I;
       
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
            CheckStonTiming();
            gameManager.isMining = true;

        }
        if (inputCount == 5)
        {
            
            Quarry.SetActive(false);
            SetScore();
            totalGold = 0;
            gameManager.isMining = false;
            

        }
       
        Gold.text = totalGold.ToString();
    }
    public void CheckStonTiming()
    {
        float StonePosX = Stone.transform.localPosition.x;
        for (int x = 0; x < timingBoxs.Length; x++)
        {
            if (timingBoxs[x].x <= StonePosX && StonePosX <= timingBoxs[x].y)
            {
               
                StoneHitEffect();
                


                if (x == 0)
                {
                    addGold = 300;
                    
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
                JudgementEffect(x);
                return;
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
    public void JudgementEffect(int num)
    {
        judgemenImage.sprite = judementSprite[num];
        judgementAnimator.SetTrigger(hit);
    }
}
