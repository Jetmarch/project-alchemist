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
        Item item = FindAndInstantiateItem("Flower of the God");

        if (item != null)
        {
            item.onUse += EffectManager.OnUse_TestItem;
            return item;
        }

        return null;
    }

    public Item CreateMagicItem()
    {
        Item item = FindAndInstantiateItem("Saint Graal");
        
        if(item != null)
        {
            item.onUse += EffectManager.OnUse_TestItem;
            item.onStartUsing += EffectManager.OnStartUse_TestItem;
            item.onStopUsing += EffectManager.OnStopUse_TestItem;
            return item;
        }

        return null;
    }

    private Item FindAndInstantiateItem(string itemName)
    {
        Item foundedItem;
        foreach (var item in allGameItems)
        {
            if (item.m_name == itemName)
            {
                foundedItem = Instantiate(item);
                return foundedItem;
            }
        }

        return null;
    }
}
