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

    public bool UseConsumable(string itemName)
    {
        if (this.itemName == itemName)
        {
            if (statToChange == ConsumableStat.Health)
            {
                Debug.Log("How many times come here");

                PlayerHealth playerHealth = GameObject.Find("HealthCanvas").GetComponent<PlayerHealth>();
                if (playerHealth.health >= playerHealth.maxHealth)
                {
                    return false;
                }
                else
                {
                    playerHealth.ChangeHealth(amountToChangeStat);
                    return true;
                }
            }
        }
        return false;
    }
    
}
