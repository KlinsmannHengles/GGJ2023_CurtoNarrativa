using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGeneral : MonoBehaviour
{

    public static PlayerGeneral Instance { get; private set; }

    [Header("Inventory")]
    public GameObject[] inventoryItems;

    [Header("InventoryUI")]
    public Image[] inventorySlotsUI;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    // check if an item is in the player inventory
    public bool CheckItemInventory(string itemName)
    {
        for(int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i].name == itemName)
            {
                return true;
            }
        }

        return false;
    }

    // add an item to the player inventory
    public void AddItemToInventory(GameObject item)
    {
        if (CheckIfPlayerInventoryIsFull())
        {
            Debug.Log("Player inventory is full");
            return;
        }

        for (int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i] == null)
            {
                inventoryItems[i] = item;

                AddToUIInventory(item.GetComponent<SpriteRenderer>().sprite, i);

                return;
            }
        }
    }

    // check if all the player inventory is full
    public bool CheckIfPlayerInventoryIsFull()
    {
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i] == null)
            {
                return false;
            }
        }
        return true;
    }

    // add the object image to the ui inventory slot
    public void AddToUIInventory(Sprite sprite, int slot)
    {
        inventorySlotsUI[slot].sprite = sprite;
    }

}
