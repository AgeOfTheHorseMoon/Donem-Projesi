using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;


public class ItemSlot : MonoBehaviour
{
    public string itemName;
    public int quantitiy;
    public Sprite itemSprite;
    public bool isFull;


    [SerializeField]
    private TMP_Text quantitiyText;

    [SerializeField]
    private Image itemImage;
    
    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.quantitiy = quantity;
        this.itemSprite = itemSprite;
        isFull = true;

        quantitiyText.text = quantity.ToString();
        quantitiyText.enabled = true;
        itemImage.sprite = itemSprite;
    }
}
