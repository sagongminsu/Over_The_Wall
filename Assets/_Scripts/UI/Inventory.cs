using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
    public ItemData_ itemData;

    
    public ItemSlot[] slots;

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
    public GameObject unEquipButton;
    public GameObject dropButton;

    private int curEquipIndex;

    private PlayerInput playerinput;
    private PlayerConditions conditoion;

    [Header("Events")]
    public UnityEvent onOpenInventiry;
    public UnityEvent onCloseInventory;

    public static Inventory instance;

   
    private void Update()
    {
        if (Input.GetKeyDown(OpenInven))
        {
            Toggle();
        }
    }

    private void Toggle()
    {
        bool Open = Inven.activeSelf;
        Inven.SetActive(!Open);
    }


    //void Awake()
    //{
    //    instance = this;
    //    playerinput = GetComponent<PlayerInput>();
    //    condition = GetComponent<PlayerController>();
    //}
    //private void Start()
    //{
    //    inventoryWindow.SetActive(false);
    //    slots = new ItemSlot[uiSlots.Length];
    //    for (int i = 0; i < slots.Length; i++)
    //    {
    //        slots[i] = new ItemSlot();
    //        uiSlots[i].index = i;
    //        uiSlots[i].Clear();
    //    }
    //    ClearSelectedItemWindow();
    //}

   
  

    //public void AddItem(ItemData item)
    //{
    //    if (item.canStack)
    //    {
    //        ItemSlot slotToStackTo = GetItemStack(item);
    //        if (slotToStackTo != null)
    //        {
    //            slotToStackTo.quantity++;
    //            UPdateUI();
    //            return;
    //        }
    //    }
    //    ItemSlot emptySlot = GetEmptySlot();
    //    if (emptySlot != null)
    //    {
    //        emptySlot.item = item;
    //        emptySlot.quantity = 1;
    //        UPdateUI();
    //        return;
    //    }
    //    ThrowItem(item);
    //}

    //void ThrowItem(itemData item)
    //{
    //    Instantiate(item.dropPrefab, dropPosition.position, Quaternion.Euler(Vector3.one * Random.value * 360f))
    //    }

    //void UPdateUI()
    //{
    //    for (int i = 0; i < slots.Length; i++)
    //    {
    //        if (slots[i].item != null)
    //        {
    //            uiSlots[i].Set(slots[i]);

    //        }
    //        else
    //        {
    //            uiSlots[i].Clear();
    //        }
    //    }
    //}

    //ItemSlot GetItemStack(ItemSlot item)
    //{
    //    for (int i = 0; i < slots.Length; i++)
    //    {
    //        if (slots[i].item == item && slots[i].quantity < item.maxStackAmount)
    //        {
    //            return slots[i];
    //        }
    //    }
    //    return null;
    //}

    //ItemSlot GetEmptySlot()
    //{
    //    for (int i = 0; i < slots.Length; i++)
    //    {
    //        if (slots[i].item == null)
    //        {
    //            return slots[i];
    //        }
    //    }
    //    return null;
    //}

    //public void SelectItem(int index)
    //{
    //    if (slots[index].item == null)
    //        return;

    //    selectedItem = slots[index];
    //    selectedItemIndex = index;

    //    selectedItemName.text = selectedItem.item.displayName;
    //    selectedItemDescription.text = selectedItem.item.description;

    //    selectedItemStatNames.text = string.Empty;
    //    selectedItemStatValues.text = string.Empty;

    //    for (int i = 0; i < selectedItem.item.c)
    //        useButton.SetActive(selectedItem.item.type == ItemType.Consumable);
    //    equipButton.SetActive(selectedItem.item.type == ItemType.Equipable && !uiSlots[index].equipped);
    //    unEquipButton.SetActive(selectedItem.item.type == ItemType.Equipable && uiSlots[index].equipped);
    //    dropButton.SetActive(true);
    //}
    //private void ClearSelectedItemWindow()
    //{
    //    selectedItem = null;
    //    selectedItemName.text = string.Empty;
    //    selectedItemDescription.text = string.Empty;

    //    selectedItemStatNames.text = string.Empty;
        

    //    useButton.SetActive(false);
    //    equipButton.SetActive(false);
    //    unEquipButton.SetActive(false);
    //    dropButton.SetActive(false);
    //}
    //public void OnEquipButton()
    //{

    //}
    //void UnEquip(int index)
    //{

    //}
    //public void OnUnEquipButton()
    //{

    //}
    //public void OnDropButton()
    //{
    //    ThrowItem(selectedItem.item);
    //    RemoveSelectedItem();
    //}
    //public void OnUseButton()
    //{
    //    if (selecteditem.item.type == itemtype.consumable)
    //    {
    //        for (int i = 0; i < selecteditem.item.consumables.length; i++)
    //        {
    //            switch (selecteditem.item.consumables[i].type)
    //            {
    //                case consumabletype.health:
    //                    condition.heal(selecteditem.item.consumables[i].value); break;
    //                case consumabletype.hunger:
    //                    condition.eat(selecteditem.item.consumables[i].value); break;
    //            }
    //        }
    //    }
    //    RemoveSelectedItem();
    //}
    //private void RemoveSelectedItem(ItemData item)
    //{
    //    selectedItem.quantity--;

    //    if (selectedItem.quantity <= 0)
    //    {
    //        if (uiSlots[selectedItemIndex].equipped)
    //        {
    //            UnEquip(selectedItemIndex);
    //        }

    //        selectedItem.item = null;
    //        ClearSeletecItemWindow();
    //    }

    //    UpdateUI();
    //}

    //public void RemoveItem(ItemData item, int quantity)
    //{

    //}

    //public bool HasItems(ItemData item, int quantity)
    //{
    //    return false;
    //}
}

