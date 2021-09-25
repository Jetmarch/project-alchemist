using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory
{
    public List<Item> items;
    public event EventHandler OnItemsChange;

    public Inventory()
    {
        items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        OnItemsChange?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        OnItemsChange?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem(GameObject player, Item item)
    {
        item.Use(player, item);
    }

    public List<Item> GetAllItems()
    {
        return items;
    }
}
