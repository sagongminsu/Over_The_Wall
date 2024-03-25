using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private static InteractionManager instance;

    public static InteractionManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("InteractionManager").AddComponent<InteractionManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public GameObject CurrentInteractGameObject { get; private set; }
    public IInteraction CurrentInteraction { get; private set; }


    public void SetCurrentInteraction(GameObject interactObject)
    {
        CurrentInteractGameObject = interactObject;
        CurrentInteraction = interactObject?.GetComponent<IInteraction>();
    }
}