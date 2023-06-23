using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Sword, Bow, Hammer, Club, Katana, Potion, Book , Helmet , BodyArmor 
    } 
    

    //=====Item Data=====//
    public ItemType type;
    public float itemDamage, itemDurability, itemRange;
    public int healingPoints, quantity, armorPoint , value;
    public Sprite itemSprite;
    public string itemName, itemDescription;
    //===================//

    private InventoryManager inventoryManager;


    
    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }
}
