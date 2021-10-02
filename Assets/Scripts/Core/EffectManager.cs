using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static void OnUse_TestItem(GameObject player, Item item)
    {
        Debug.Log($"Test item {item.m_name} used by {player.name}");
    }

    public static void OnStartUse_TestItem(GameObject player, Item item)
    {
        Debug.Log($"Start using item {item.m_name}");
    }

    public static void OnStopUse_TestItem(GameObject player, Item item)
    {
        Debug.Log($"Stop using item {item.m_name}");
    }
}
