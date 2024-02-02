using System.Collections;
using UnityEngine;

public class SittingChair : MonoBehaviour, IInteraction
{
    private Transform PlayerTransform;
    bool isSitting = false;

    void Start()
    {
        
    }

    public void OnInteract()
    {
        if (!isSitting)
        {
            StartCoroutine(Sitting());
        }
    }

    IEnumerator Sitting()
    {
        isSitting = true;

            yield return null;
    }

    public string GetInteractPrompt()
    {
        return "Interaction ¾É±â";
    }

}