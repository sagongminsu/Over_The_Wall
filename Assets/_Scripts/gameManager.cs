using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    public DayNightCycle dayNightCycle;
    
    public static gameManager I;

    void Awake()
    {
        I = this;
    }
    public bool CheckTime(int startTime, int endTime)
    {
        if(dayNightCycle.Hours >= startTime && dayNightCycle.Hours <= endTime )
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}
