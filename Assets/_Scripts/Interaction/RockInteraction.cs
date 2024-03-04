using UnityEngine;

public class RockInteraction : MonoBehaviour, IInteraction
{

    public void OnInteract()
    {
        Debug.Log("Ã¤±¤!");
    }

    public string GetInteractPrompt()
    {
        return "Interaction Ã¤±¤";
    }
}
