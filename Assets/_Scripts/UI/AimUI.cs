using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AimUI : MonoBehaviour
{
    public GameObject MeleeAim;
    public GameObject RangeAim;

    private void Awake()
    {
        MeleeAim = GameObject.Find("MeleeAim");
        RangeAim = GameObject.Find("RangeAim");
    }

    private void Start()
    {
        ResetCrossHair();
    }
    public void CheckWeaponType(bool IsMelee) //Melee = true, Range = false
    {
        if (IsMelee)
        {
            MeleeAim.SetActive(true);
        }
        else
        {
            RangeAim.SetActive(true);
        }
    }
    public void ResetCrossHair()
    {
        MeleeAim.SetActive(false); 
        RangeAim.SetActive(false);
    }
}
