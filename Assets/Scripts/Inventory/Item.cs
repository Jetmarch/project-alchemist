using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string m_name;
    public string description;
    public Sprite sprite;
    public ItemType type;
    public ItemEffect itemEffect;


    public delegate void UseHandler(GameObject gameObject, Item item);
    public event UseHandler OnUse;

    public void Use(GameObject gameObject, Item item)
    {
        if(OnUse != null)
        {
            OnUse.Invoke(gameObject, item);
        }
    }
}

public enum ItemType
{
    Ingredient,
    Potion
}
