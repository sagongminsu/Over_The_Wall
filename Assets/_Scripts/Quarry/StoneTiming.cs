using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTiming : MonoBehaviour
{
    public GameObject Stone;
    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    [SerializeField] Animator StoneHit = null;

    string hit = "Hit";
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
            CheckTiming();
        }
    }
    public void CheckTiming()
    {
        float StonePosX = Stone.transform.localPosition.x;
        for (int x = 0; x < timingBoxs.Length; x++)
        {
            if (timingBoxs[x].x <= StonePosX && StonePosX <= timingBoxs[x].y)
            {
                Debug.Log(x);

            }
            else
            {
                Debug.Log("Fail");
            }
            StoneHitEffect();
        }
    }
    public void StoneHitEffect()
    {
        StoneHit.SetTrigger(hit);
    }
}
