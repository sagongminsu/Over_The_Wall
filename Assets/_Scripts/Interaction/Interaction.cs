using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private InteractionManager interactionManager;

    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;
    private IInteraction curInteraction;

    public TextMeshProUGUI promptText;
    private Camera camera;

    // 셰이더로부터 받은 윤곽선 머티리얼
    public Material outlineMaterial;
    private Material originalMaterial;

    // 각 오브젝트의 원래 Material을 저장할 딕셔너리
    //private Dictionary<GameObject, Material> originalMaterials = new Dictionary<GameObject, Material>();

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

                    // 윤곽선 적용
                    ApplyOutline(hitObject, true);
                }
            }
            else
            {
                if (interactionManager.CurrentInteractGameObject == null) return;

                ApplyOutline(interactionManager.CurrentInteractGameObject, false);
                //originalMaterials.Clear();

                interactionManager.SetCurrentInteraction(null);
                promptText.gameObject.SetActive(false);
            }
        }
    }

    private void SetPromptText()
    {
        promptText.gameObject.SetActive(true);

        // curInteraction에 값을 할당
        curInteraction = interactionManager.CurrentInteraction;

        if (curInteraction != null)
        {
            promptText.text = string.Format("<b>[E]</b> {0}", curInteraction.GetInteractPrompt());
        }
        else
        {
            Debug.Log("curInteraction is null!");
        }
    }

    private void ApplyOutline(GameObject obj, bool apply)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer == null)
            return;

        if (apply)
        {
            // 원래 Material을 저장하고, outlineMaterial을 적용
            if (originalMaterial == null)
            {
                originalMaterial = renderer.material;
                renderer.material = outlineMaterial;
            }
        }
        else
        {
            // outlineMaterial을 적용했던 것을 원래 Material로 되돌림
            if (originalMaterial != null)
            {
                renderer.material = originalMaterial;
                originalMaterial = null;
            }
        }
    }
}
