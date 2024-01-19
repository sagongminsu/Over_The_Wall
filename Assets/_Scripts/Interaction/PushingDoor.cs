using UnityEngine;


public class PushingDoor : MonoBehaviour, IInteraction
{
    public JsonLoader.ItemData associatedData;
    float openRotationY = 90f;
    float closeRotationY = 0f;
    public void OnInteract()
    {
        if (transform.rotation.eulerAngles.y != 90f)
        {
            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, openRotationY, transform.rotation.eulerAngles.z);
            transform.rotation = targetRotation;
        }
        else
        {
            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, closeRotationY, transform.rotation.eulerAngles.z);
            transform.rotation = targetRotation;
        }
    }
    public string GetInteractPrompt()
    {
        if (associatedData != null && associatedData.ItemList.Count == 6)
        {

            JsonLoader.ItemData.Item item = associatedData.ItemList[6];
            return string.Format("Interaction {0}", item.InteractionName);

        }
        else
        {
            return "Interaction";
        }
    }
}
