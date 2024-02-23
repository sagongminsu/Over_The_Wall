using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitUI : MonoBehaviour
{
    gameManager gameManager;

    private void Awake()
    {
        gameManager = gameManager.I;
    }
    public void timeScale(float Value)
    {
        Time.timeScale = Value;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Exit(GameObject gameObject)
    {
        StartCoroutine(ExitCoroutine(gameObject, 0.5f));
        gameManager.isPause = false;
    }

    private IEnumerator ExitCoroutine(GameObject gameObject, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        gameObject.SetActive(false);
    }
}
