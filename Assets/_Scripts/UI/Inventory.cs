using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemSlot
{
    public ItemData_ item;
    public int quantity;
}
public class Inventory : MonoBehaviour
{
    public KeyCode OpenInven;
    public ItemSlotUI[] uiSlots;
    public GameObject Inven;
    public ItemData_ itemData_;
    public Shop shop;

    public ItemSlot[] slots;

    public GameObject inventoryWindow;
    public Transform dropPosition;

    [Header("Selected Item")]
    private ItemSlot selectedItem;
    private int selectedItemIndex;
    public TMPro.TextMeshProUGUI selectedItemName;
    public TMPro.TextMeshProUGUI selectedItemDescription;
    public TMPro.TextMeshProUGUI selectedItemStatNames;
    public TMPro.TextMeshProUGUI selectedItemStatValues;
    public GameObject useButton;
    public GameObject equipButton;
    public GameObject unEquipButton;

    private int curEquipIndex;

    private PlayerInput playerInput;
    public PlayerConditions playerConditions;
    public QuestManager questManager;

    [Header("Events")]
    public UnityEvent onOpenInventiry;
    public UnityEvent onCloseInventory;

    public static Inventory instance;
    public ItemData_ baton;

    void Awake()
    {   
        if(instance == null)
        {
   
            instance = this;
            DontDestroyOnLoad(this);

        }
    }
    private void Start()
    {
        //gameManager.I.ToggleInven += ToggleInven;
        slots = new ItemSlot[uiSlots.Length];
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot();
            uiSlots[i].index = i;
            uiSlots[i].Clear();
        }
        slots[0] = new ItemSlot() { item = baton, quantity = 1 };
        UpdateUi();
        ClearSelectedItemWindow();
        //inventoryWindow.SetActive(false);
    }


    private void ToggleInven(bool isOpen)
    {
        Inven.SetActive(isOpen);
    }



    public void AddItem(ItemData_ item)
    {
        if (item.type == ItemType.Quest)
        {
            QuestManager.instance.CompleteQuest(item.QuestNum);
        }
        if (item.canStack)
        {
            ItemSlot slotToStackTo = GetItemStack(item);
            if (slotToStackTo != null)
            {
                slotToStackTo.quantity++;
                UpdateUi();
                return;
            }
        }
        ItemSlot emptySlot = GetEmptySlot();
        if (emptySlot != null)
        {

            emptySlot.item = item;
            emptySlot.quantity = 1;
            UpdateUi();
            return;
        }
        ThrowItem(item);
    }

    void ThrowItem(ItemData_ item)
    {
        Instantiate(item.dropPrefab, dropPosition.position, Quaternion.Euler(Vector3.one * Random.value * 360f));
    }

    void UpdateUi()
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

    ItemSlot GetItemStack(ItemData_ item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == item && slots[i].quantity < item.maxStackAmount)
            {
                return slots[i];
            }
        }
        return null;
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
        useButton.SetActive(selectedItem.item.type == ItemType.Consumable);
        equipButton.SetActive(selectedItem.item.type == ItemType.Equipable && !uiSlots[index].equipped);
        unEquipButton.SetActive(selectedItem.item.type == ItemType.Equipable && uiSlots[index].equipped);

    }
    private void ClearSelectedItemWindow()
    {
        selectedItem = null;
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;
        selectedItemStatValues.text = string.Empty;
        selectedItemStatNames.text = string.Empty;


        useButton.SetActive(false);
        equipButton.SetActive(false);
        unEquipButton.SetActive(false);
    }

    public void OnEquipButton()
    {
        if (uiSlots[curEquipIndex].equipped)
        {
            UnEquip(selectedItemIndex);
        }

        uiSlots[selectedItemIndex].equipped = true;
        curEquipIndex = selectedItemIndex;
        EquipManager.instance.EquipNew(selectedItem.item);
        UpdateUi();

        SelectItem(selectedItemIndex);
    }

    void UnEquip(int index)
    {
        uiSlots[index].equipped = false;
        EquipManager.instance.UnEquip();
        UpdateUi();

        if (selectedItemIndex == index)
            SelectItem(index);
    }

    public void OnUnEquipButton()
    {
        UnEquip(selectedItemIndex);
    }
    
    public void OnUseButton()
    {
        if (selectedItem.item.type == ItemType.Consumable)
        {
            for (int i = 0; i < selectedItem.item.consumables.Length; i++)
            {
                switch (selectedItem.item.consumables[i].type)
                {
                    case ConsumableType.Health:
                        playerConditions.Heal(selectedItem.item.consumables[i].value); break;
                    case ConsumableType.Hunger:
                        playerConditions.Eat(selectedItem.item.consumables[i].value); break;
                }
            }
            
        }
        if (gameManager.I.dayNightCycle.Days == 1 && selectedItem.item.name == "Food")
        {
            QuestManager.instance.CompleteQuest(3);
        }
        RemoveSelectedItem(selectedItem.item);
    }
    private void RemoveSelectedItem(ItemData_ item)
    {
        selectedItem.quantity--;

        if (selectedItem.quantity <= 0)
        {
            if (uiSlots[selectedItemIndex].equipped)
            {
                UnEquip(selectedItemIndex);
            }

            selectedItem.item = null;
            ClearSelectedItemWindow();
        }

        UpdateUi();
    }

    public void RemoveItem(ItemData_ item, int quantity)
    {
      
    }

    public bool HasItems(ItemData_ item, int quantity)
    {
        return false;
    }

    public int CheckItemCount(ItemData_ item)
    {
        int Count = 0;
        ItemSlot slotToStackTo = GetItemStack(item);
        if (slotToStackTo != null)
        {
            Count = slotToStackTo.quantity;
        }
        return Count;
    }

    public bool CheckQuestCompletion(ItemData_ item, int requiredQuantity)
    {
        int itemCount = CheckItemCount(item);

        if (itemCount >= requiredQuantity)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}

