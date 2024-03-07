using UnityEngine;

public class RockInteraction : MonoBehaviour, IInteraction
{
    public GameObject Quarry;
    gameManager gameManager;
    public StoneTiming stoneTiming;
    private void Awake()
    {
        
        stoneTiming = GetComponent<StoneTiming>();

    }
    private void Start()
    {
        gameManager = gameManager.I;
      
    }
    private void Update()
    {
      

    }
    public void OnInteract()
    {
        Quarry.SetActive(true);
        gameManager.isMining = true;
    }

    public string GetInteractPrompt()
    {
        return "Interaction Ã¤±¤";
    }
    
}
