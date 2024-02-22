using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleController : MonoBehaviour
{
    public void TimeScaleControl(float Value)
    {
        Time.timeScale = Value;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
