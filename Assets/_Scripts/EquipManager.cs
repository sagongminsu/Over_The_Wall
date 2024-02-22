using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public GameObject curEquip;
    public Transform equipParent;

    public bool isEquipped = false;

    public static EquipManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void EquipNew(ItemData_ item)
    {
        UnEquip();
        curEquip = Instantiate(item.equipPrefab, equipParent);
        isEquipped = true;
        Debug.Log("����");
    }

    public void UnEquip()
    {
        if (curEquip != null)
        {
            Destroy(curEquip.gameObject);
            curEquip = null;
            isEquipped = false;
            Debug.Log("���� ����");
        }
    }
}