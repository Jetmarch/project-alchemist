using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static void OnUse_TestItem(GameObject gameObject, Item item)
    {
        Debug.Log($"Test item {item.m_name} used by {gameObject.name}");
    }
}
