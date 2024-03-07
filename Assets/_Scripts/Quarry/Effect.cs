using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    

    [SerializeField] Animator StoneHit = null;
    [SerializeField] Animator judgementAnimator = null;
    [SerializeField] UnityEngine.UI.Image judgementImage = null;
    [SerializeField] Sprite[] judgementSprite = null;

    public string hit = "Hit";


    // Update is called once per frame
    public void StoneHitEffect()
    {
        StoneHit.SetTrigger(hit);
    }

    public void JudgmentEffect(int num)
    {
        judgementImage.sprite = judgementSprite[num];
        judgementAnimator.SetTrigger(hit);
    }
}
