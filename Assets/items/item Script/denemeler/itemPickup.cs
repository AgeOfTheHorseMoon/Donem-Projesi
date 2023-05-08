using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickup : MonoBehaviour
{
    public item Item;

    void Pickup()
    {
        InventoryManager.Instance.add(Item);
        Destroy(gameObject);
    }

    public void ItemPickup()
    {
        
        Pickup();
    }
}
