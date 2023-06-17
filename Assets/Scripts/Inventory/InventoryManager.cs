using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryMenu;
    public bool inventoryopen;
    public ItemSlot[] itemSlot;
    public Camera mainCamera;
    public ItemSO[] items;


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab) && inventoryopen)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            //mainCamera.GetComponent<Camera>().enabled = true;
            Time.timeScale = 1;
            inventoryMenu.SetActive(false);
            inventoryopen = false;
        }
        else if (Input.GetKeyUp(KeyCode.Tab) && !inventoryopen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            // mainCamera.GetComponent<Camera>().enabled = false;
            Time.timeScale = 0;
            inventoryMenu.SetActive(true);
            inventoryopen = true;
        }
    }

    public void UseConsumable(string itemName)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if (items[i].itemName == itemName)
            {
                items[i].UseConsumable(itemName);
            }
        }
    }

    public int AddItem(string itemName, int quantity , Sprite itemSprite , string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            Debug.Log("number" + i);
            if (itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantitiy == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                if (leftOverItems > 0) 
                {
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription);
                }
                return leftOverItems;
            }
        }
        return quantity;
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
}
