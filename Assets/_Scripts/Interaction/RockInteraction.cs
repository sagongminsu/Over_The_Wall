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
        if (stoneTiming.inputCount == 5)
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Interatable");

        }

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
