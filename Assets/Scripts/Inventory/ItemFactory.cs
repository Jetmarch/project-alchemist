using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    [SerializeField] private List<Item> allGameItems;

    public static ItemFactory instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public Item CreateIngredientFlowerOfTheGod()
    {
        Item item = FindItem("Flower of the God");

        if (item != null)
        {
            Debug.Log($"Created item {item.name}");
            item.OnUse += EffectManager.OnUse_TestItem;
            return item;
        }

        return null;
    }

    private Item FindItem(string itemName)
    {
        Item foundedItem;
        foreach (var item in allGameItems)
        {
            if (item.m_name == itemName)
            {
                foundedItem = item;
                return foundedItem;
            }
        }
        return null;
    }
}
