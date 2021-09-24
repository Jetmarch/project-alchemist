using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemEffect
{
    public delegate void EffectDelegate(GameObject gameObject, Item item);
    public delegate void EffectDelegateUpdate(GameObject gameObject, Item item, float deltaTime);

    public event EffectDelegate onStartUsing;
    public event EffectDelegate onStopUsing;
    public event EffectDelegateUpdate onUpdate;
}
