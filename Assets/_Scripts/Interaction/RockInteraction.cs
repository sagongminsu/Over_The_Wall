using UnityEngine;

public class RockInteraction : MonoBehaviour, IInteraction
{
    public GameObject Quarry;
    public void OnInteract()
    {
        Quarry.SetActive(true);
    }

    public string GetInteractPrompt()
    {
        return "Interaction Ã¤±¤";
    }
}
