using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot
{
    public int quntity;
}
public class ItemSlotUi : MonoBehaviour
{
    public ItemSlotUi[] UiSlot;
    public ItemSlot[] slts;
    public GameObject inventoryWindow;
    public Transform dropPosition;

    [Header("Selected Item")]
    private ItemSlot selectedItem;
    public int selectedItemIndex;
    public TMPro.TextMeshProUGUI selectedItemName;
        
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
