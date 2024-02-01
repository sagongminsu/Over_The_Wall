using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemSlot
{
    public int quantity;
}
public class Inventory : MonoBehaviour
{
    public KeyCode OpenInven;
    public ItemSlotUI[] uiSlots;
    public GameObject Inven;

    private void Update()
    {
        KeyCode result = OpenInven;
        if (result == OpenInven)
        {
            Inven.SetActive(true);
        }
    }


}
