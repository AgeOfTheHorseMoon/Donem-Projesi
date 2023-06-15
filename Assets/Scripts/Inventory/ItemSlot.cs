using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public ItemObject item;
    public int quantitiy;
    public Sprite itemSprite;
    public bool isFull;


    //[SerializeField]
    // private TextMeshPro_UGUI quantitiyText;

    [SerializeField]
    private Image itemImage;
    
    public void AddItem(ItemObject item, int quantity)
    {
        this.item = item;
        this.quantitiy = quantity;
        isFull = true;

        //quantitiyText.text = quantity.ToString();
        //quantitiyText.enabled = true;
        itemImage.sprite = item.itemSprite;

    }
}
