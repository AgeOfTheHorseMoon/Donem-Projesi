using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemObject item;

    public enum ItemType
    {
        Sword, Bow, Hammer, Potion, Book
    }

    public ItemType type;
    public float 
        itemDamage, itemDurability, itemRange;
    public Sprite itemSprite;
    public string itemName, itemDescription;

    private InventoryManager inventoryManager;
    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }
}
