using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Potion,
    Armor
}
public abstract class ItemObject : ScriptableObject
{
    [SerializeField]
    public string itemName;

    public GameObject prefab;
    public ItemType type;
    public Sprite itemSprite;
    [TextArea(15,20)]
    public string description;

}
