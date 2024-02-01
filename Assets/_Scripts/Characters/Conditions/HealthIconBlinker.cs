using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIconBlinker : MonoBehaviour
{
    [SerializeField]
    private Image icon;

    [SerializeField]
    private PlayerConditions playerConditions;

    private Coroutine blinkCoroutine;
    void Start()
    {
        icon.color = Color.clear;
    }
    void Update()
    {
        Condition health = playerConditions.health;

        if (health.GetPercentage() <= 0.2f && blinkCoroutine == null)
        {
            blinkCoroutine = StartCoroutine(Blink());
        }
        else if (health.GetPercentage() > 0.2f && blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            blinkCoroutine = null;
            icon.color = Color.white;
        }
    }

    IEnumerator Blink()
    {
        while (true)
        {
            icon.color = Color.clear;
            yield return new WaitForSeconds(0.5f);
            icon.color = Color.white;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
