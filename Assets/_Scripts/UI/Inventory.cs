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
    public ItemSlotUI[] uiSlot;
    public ItemSlot[] slts;

    public GameObject inventoryWindow;
    public Transform dropPosition;

    [Header("Selected Item")]
    private ItemSlot selectedItem;
    private int selectedItemIndex;
    public TMPro.TextMeshProUGUI selectedItemName;
    public TMPro.TextMeshProUGUI selectedItemDescription;
    public TMPro.TextMeshProUGUI selectedItemStatNames;
    public TMPro.TextMeshProUGUI selectedItemCount;
    public GameObject useButton;
    public GameObject equipButton;
    public GameObject unEquiptton;
    public GameObject DropButton;

    private int curEquipIndex;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
