using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public List<Item> items = new List<Item>();
    public GameEvent onInventoryChanged;
    public int maxItemCount;

    public bool AddItem(Item item)
    {
        if(items.Count >= maxItemCount)
        {
            return false;
        }

        items.Add(item);
        onInventoryChanged.Raise();
        return true;
    }

    public void RemoveItem(Item item)
    {
        if(items.Count == 0)
        {
            return;
        }

        items.Remove(item);
        onInventoryChanged.Raise();
    }

    public List<Item> GetAllItems()
    {
        return items;
    }
}
