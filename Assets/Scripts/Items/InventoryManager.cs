using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<PickableItem> items;

    private void Start()
    {
        items = new List<PickableItem>();
    }

    public void AddItem(PickableItem itemToAdd)
    {
        items.Add(itemToAdd);
    }

    public void ShowItems()
    {
        Debug.Log("In inventory");
        foreach(var item in items)
        {
            Debug.Log("Item: " + item.itemName);
        }
    }
}
