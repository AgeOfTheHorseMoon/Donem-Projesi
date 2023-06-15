using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryMenu;
    public bool inventoryopen;
    public ItemSlot[] itemSlot;
    public Camera mainCamera;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab) && inventoryopen)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            mainCamera.GetComponent<Camera>().enabled = true;
            Time.timeScale = 1;
            inventoryMenu.SetActive(false);
            inventoryopen = false;
        }
        else if (Input.GetKeyUp(KeyCode.Tab) && !inventoryopen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mainCamera.GetComponent<Camera>().enabled = false;
            Time.timeScale = 0;
            inventoryMenu.SetActive(true);
            inventoryopen = true;
        }
    }

    public void AddItem(string itemName, int quantity , Sprite itemSprite)
    {
        Debug.Log("itemName=" +itemName);
    }
}
