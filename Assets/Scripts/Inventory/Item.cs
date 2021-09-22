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
}

public enum ItemType
{
    Ingredient,
    Potion
}
