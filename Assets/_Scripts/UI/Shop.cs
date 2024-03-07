using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GoldManager goldManager;

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
    public GameObject ReturnBuyButton;
    public GameObject ReturnButton;

    public ItemData_ Coffee;
    public ItemData_ Cigarette;

    private void Start()
    {
        goldManager = GoldManager.instance;
        slots = new ItemSlot[uiSlots.Length];
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot();
            uiSlots[i].index = i;
            uiSlots[i].Clear();
        }
        slots[0] = new ItemSlot() { item = Coffee, quantity = 1 };
        slots[1] = new ItemSlot() { item = Cigarette, quantity = 1 };
        UpdateUi();
        
    }

    private void Update()
    {
       
    }

    public void ItemSetting(ItemData_ item)
    {

    }

    public void UseBuyButton(ItemData_ item)
    {
        goldManager.Gold -= selectedItem.item.price;

        
      

    }
    public void UseSoldButton()
    {
        
        

    }
    public void UseReturnButton()
    {
        Cursor.lockState = CursorLockMode.Locked;
        ShopUI.SetActive(false);
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
