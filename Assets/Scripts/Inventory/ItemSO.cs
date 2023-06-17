using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public Item item;
    public enum ConsumableStat
    {
        Health,
        Mana,
        Stamina
    }

    //========Consumable Stat======//
    public string itemName;
    public ConsumableStat statToChange = new ConsumableStat();
    public int amountToChangeStat;

    //===================//

    public void UseConsumable(string itemName)
    {
        if (this.itemName == itemName)
        {
            if (statToChange == ConsumableStat.Health)
            {
                GameObject.Find("HealthCanvas").GetComponent<PlayerHealth>().ChangeHealth(amountToChangeStat);
            }
        }
    }
}
