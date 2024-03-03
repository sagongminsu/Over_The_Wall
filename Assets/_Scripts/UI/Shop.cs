using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject ShopMan;
    public GameObject ShopUI;
    public GameObject Inven;
    public ItemSlotUI[] uiSlots;
    public ItemSlot[] slots;

    public ItemData_ itemData_;
    public Inventory Inventory;

    [Header("Selected Item")]
    private ItemSlot selectedItem;
    private int selectedItemIndex;
    public TMPro.TextMeshProUGUI selectedItemName;
    public TMPro.TextMeshProUGUI selectedItemDescription;
    public TMPro.TextMeshProUGUI selectedItemStatNames;
    public TMPro.TextMeshProUGUI selectedItemStatValues;

    public GameObject BuyButton;
    public GameObject SoldButton;
    public GameObject ReturnButton;

    void Start()
    {
        slots = new ItemSlot[uiSlots.Length];
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot();
            uiSlots[i].index = i;
            uiSlots[i].Clear();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.I.CheckTime(14, 17))
        {
            ShopMan.SetActive(true);
        }
        else
        {
            ShopMan.SetActive(false);
        }
    }

    public void ItemSetting(ItemData_ item)
    {

    }

    public void UseBuyButton()
    {
        

    }
    public void UseSoldButton()
    {
        Inven.SetActive(true);
        ReturnButton.SetActive(true);

    }
    public void UseReturnButton()
    {
        ShopUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
    private void UpdateUi()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                uiSlots[i].Set(slots[i]);

            }
            else
            {
                uiSlots[i].Clear();
            }
        }
    }
    ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                return slots[i];
            }
        }
        return null;
    }
    public void SelectItem(int index)
    {
        if (slots[index].item == null)
            return;

        selectedItem = slots[index];
        selectedItemIndex = index;

        selectedItemName.text = selectedItem.item.displayName;
        selectedItemDescription.text = selectedItem.item.description;

        selectedItemStatNames.text = string.Empty;
        selectedItemStatValues.text = string.Empty;

        for (int i = 0; i < selectedItem.item.consumables.Length; i++)
        {
            selectedItemStatNames.text += selectedItem.item.consumables[i].type.ToString() + "\n";
            selectedItemStatValues.text += selectedItem.item.consumables[i].value.ToString() + "\n";
        }
    }
}
