using UnityEngine;

public class RockInteraction : MonoBehaviour, IInteraction
{
    public GameObject Quarry;
    GoldManager goldManager;
    public StoneTiming stoneTiming;
    private void Awake()
    {
        goldManager = GoldManager.instance;
        stoneTiming = GetComponent<StoneTiming>();

    }
    private void Update()
    {
      

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
