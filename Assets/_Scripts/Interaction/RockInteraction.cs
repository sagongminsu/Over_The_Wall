using UnityEngine;

public class RockInteraction : MonoBehaviour, IInteraction
{
    public GameObject Quarry;
    GoldManager goldManager;

    private void Awake()
    {
        goldManager = GoldManager.instance;
    }

    public void OnInteract()
    {
        Quarry.SetActive(true);
        goldManager.isMining = true;
    }

    public string GetInteractPrompt()
    {
        return "Interaction Ã¤±¤";
    }
}
