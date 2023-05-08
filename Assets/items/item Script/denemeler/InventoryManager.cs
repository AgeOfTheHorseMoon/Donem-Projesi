using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<item> Items = new List<item>();

    public Transform ItemContent;
    public GameObject InventoryItem;
    private void Awake()
    {
        Instance = this;
    }

    public void add(item item)
    { 
        Items.Add(item);  
    }

    public void remove(item item) 
    {
        Items.Remove(item);  
    }

    public void add(List<item> list)
    { 
        for (int i = 0; i < list.Count; i++) 
        {
            Items.Add(list[i]);
        }
    }

    public void ListItems()
    {
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem,ItemContent);
            var itemName = obj.transform.Find("Item/ItemName").GetComponent<string>();
            var itemIcon = obj.transform.Find("Item/ItemName").GetComponent<Sprite>();

            itemName = item.itemName;
            itemIcon = item.icon;
        }
        
    }
}
