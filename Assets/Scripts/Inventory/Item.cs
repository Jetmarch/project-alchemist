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

    public delegate void EffectDelegate(GameObject gameObject, Item item);
    public delegate void EffectDelegateUpdate(GameObject gameObject, Item item, float deltaTime);

    public event EffectDelegate onStartUsing;
    public event EffectDelegate onStopUsing;
    public event EffectDelegateUpdate onUpdate;
    public event EffectDelegate onUse;

    public void Use(GameObject gameObject, Item item)
    {
        if(onUse != null)
        {
            onUse.Invoke(gameObject, item);
        }
    }

    public void UseOn(List<GameObject> gameObjects, Item item)
    {
        if(onUse != null)
        {
            foreach(var obj in gameObjects)
            {
                onUse.Invoke(obj, item);
            }
        }
    }

    public void StartUse(GameObject gameObject, Item item)
    {
        if(onStartUsing != null)
        {
            onStartUsing.Invoke(gameObject, item);
        }
    }

    public void StopUse(GameObject gameObject, Item item)
    {
        if (onStopUsing != null)
        {
            onStopUsing.Invoke(gameObject, item);
        }
    }
}

public enum ItemType
{
    Ingredient,
    Potion
}
