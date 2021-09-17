using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory
{
    public List<Item> items;
    public event EventHandler OnItemsChange;
    private Action<Item> useItemAction;

    public Inventory(Action<Item> useItemAction)
    {
        items = new List<Item>();
        this.useItemAction = useItemAction;
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

    public void UseItem(Item item)
    {
        useItemAction(item);
    }

    public List<Item> GetAllItems()
    {
        return items;
    }
}
