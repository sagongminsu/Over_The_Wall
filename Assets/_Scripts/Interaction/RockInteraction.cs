using UnityEngine;

public class RockInteraction : MonoBehaviour, IInteraction
{

    public void OnInteract()
    {
        Debug.Log("ä��!");
    }

    public string GetInteractPrompt()
    {
        return "Interaction ä��";
    }
}
