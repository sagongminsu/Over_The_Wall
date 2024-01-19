using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
public class Interaction : MonoBehaviour
{
    private InteractionManager interactionManager;

    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;
    public bool IsInteracting;

    private IInteraction curInteraction;

    public TextMeshProUGUI promptText;
    private Camera camera;

    void Start()
    {
        camera = Camera.main;
        interactionManager = InteractionManager.Instance;
    }

    void Update()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                GameObject hitObject = hit.collider.gameObject;

                if (hitObject != interactionManager.CurrentInteractGameObject)
                {
                    interactionManager.SetCurrentInteraction(hitObject);
                    SetPromptText();
                }
            }
            else
            {
                interactionManager.SetCurrentInteraction(null);
                promptText.gameObject.SetActive(false);
            }
        }
    }

    private void SetPromptText()
    {
        promptText.gameObject.SetActive(true);
        IsInteracting = true;
        promptText.text = string.Format("<b>[E]</b> {0}", curInteraction.GetInteractPrompt());
    }

    //public void OnInteraction(InputAction.CallbackContext callbackContext)
    //{
    //    Debug.Log("E");

    //    if (callbackContext.started && curInteraction != null)
    //    {
    //        curInteraction.OnInteract();
    //        curInteractGameobject = null;
    //        curInteraction = null;
    //        promptText.gameObject.SetActive(false);
    //    }
    //}
}