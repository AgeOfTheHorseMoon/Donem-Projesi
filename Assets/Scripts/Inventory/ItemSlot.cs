using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //==========Item Data=========//
    public string itemName;
    public int quantitiy;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;

    [SerializeField]
    private int maxNumberOfItems;

    //==========Item Slot=========//
    [SerializeField]
    private TMP_Text quantitiyText;

    [SerializeField]
    private Image itemImage;

    //==========Item Description Slot=========//
    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionNameText;
    public TMP_Text itemDescriptionText;





    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager =GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite ,string itemDescription)
    {
        
        if(isFull) { return quantitiy; }

        //name update
        this.itemName = itemName;

        //image update
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;

        //description update
        this.itemDescription = itemDescription;

        //Quantity update
        this.quantitiy += quantity;
        if(this.quantitiy >= maxNumberOfItems)
        {
            quantitiyText.text = maxNumberOfItems.ToString();
            quantitiyText.enabled = true;
            isFull = true;

            // leftover return
            int extraItems = this.quantitiy - maxNumberOfItems;
            this.quantitiy = maxNumberOfItems;
            return extraItems;
        }

        //quantity text update 
        quantitiyText.text = this.quantitiy.ToString();
        quantitiyText.enabled = true;

        return 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }

    }

    public void OnRightClick()
    {
        
    }

    public void OnLeftClick()
    {
        if (thisItemSelected)
        {
            inventoryManager.UseConsumable(itemName);
        }
        inventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
        itemDescriptionNameText.text = itemName;
        itemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = itemSprite;

        if (itemDescriptionImage.sprite == null)
            itemDescriptionImage.sprite = emptySprite;
    }

    
}
