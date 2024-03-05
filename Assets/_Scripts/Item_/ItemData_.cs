using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Quest,
    Equipable,
    Consumable
}

public enum ConsumableType
{
    Hunger,
    Health,
    Stemina
}

public enum WeaponType
{
    Pistol,
    OHMelee,
    THMelee,
    Range,
    Pick,
}

[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData_ : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;
    public int price;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;

    [Header("Equip")]
    public GameObject equipPrefab;
    public WeaponType weaponType;

    [Header("Quest")]
    public bool HasQuestItem;
    public int QuestNum;

}
