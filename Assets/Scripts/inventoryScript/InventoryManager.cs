using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public InventoryItemController[] inventoryItems;
    private void Awake()
    {
        Instance = this;
    }
    public void Add(Item item)
    {
        Items.Add(item);
    }
    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            GameObject.Destroy(item.gameObject);
        }
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("itemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("itemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
        inventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();
        for (int i = 0; i < Items.Count; i++)
        {
            inventoryItems[i].AddItem(Items[i]);
        }
    }
    
    public void closeInventory()
    {
        foreach (Transform item in ItemContent)
        {
            GameObject.Destroy(item.gameObject);
        }
    }
}
