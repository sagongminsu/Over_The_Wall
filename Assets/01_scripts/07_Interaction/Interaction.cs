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

    // ���̴��κ��� ���� ������ ��Ƽ����
    public Material outlineMaterial;
    private Material originalMaterial;

    // �� ������Ʈ�� ���� Material�� ������ ��ųʸ�
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

                    // ������ ����
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

        // curInteraction�� ���� �Ҵ�
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
            // ���� Material�� �����ϰ�, outlineMaterial�� ����
            if (originalMaterial == null)
            {
                originalMaterial = renderer.material;
                renderer.material = outlineMaterial;
            }
        }
        else
        {
            // outlineMaterial�� �����ߴ� ���� ���� Material�� �ǵ���
            if (originalMaterial != null)
            {
                renderer.material = originalMaterial;
                originalMaterial = null;
            }
        }
    }
}
