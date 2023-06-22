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

    public Sprite uiMaskSprite;

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
        // Creating new item
        GameObject itemToDrop = new GameObject(itemName);
        Item newItem = itemToDrop.AddComponent<Item>();
        newItem.quantity = 1;
        newItem.itemName = itemName;
        newItem.itemSprite = itemSprite;
        newItem.itemDescription = itemDescription;

        //Create and modify the SR ==== 3D ye ayarlanacak
        SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
        sr.sprite = itemSprite;
        sr.sortingOrder = 5;
        sr.sortingLayerName = "ground";

        //Add collider
        itemToDrop.AddComponent<BoxCollider>();

        //Set Location
        itemToDrop.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(0,0,1f);
        itemToDrop.transform.localScale = new Vector3(1,1,1);

        //Subtract the item 
        this.quantitiy -= 1;
        quantitiyText.text = this.quantitiy.ToString();
        if (this.quantitiy <= 0)
        {
            EmptySlot();
        }

    }

    public void OnLeftClick()
    {
        if (thisItemSelected)
        {
            bool usable = inventoryManager.UseConsumable(itemName);
            if (usable)
            {
                this.quantitiy -= 1;
                quantitiyText.text = this.quantitiy.ToString();
                if (this.quantitiy <= 0)
                {
                    EmptySlot();
                }
            }
        }
        else
        {
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

    private void EmptySlot()
    {
        quantitiyText.enabled = false;
        itemImage.sprite = uiMaskSprite;

        itemDescriptionNameText.text = null ;
        itemDescriptionText.text = null ;
        itemDescriptionImage.sprite = emptySprite;
    }
}
