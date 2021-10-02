using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class AlchemyRecipe : ScriptableObject
{
    public List<Item> materials;
    public List<Item> result;

    public List<Item> Craft(List<Item> materialsForCraft)
    {
        if(materialsForCraft.Count == 0)
        {
            return null;
        }
        //Ќаходим различи€ в листах с материалами
        //≈сли есть хоть одно, то ничего не возвращаем
        foreach(var item in materials)
        {
            foreach(var itemForCraft in materialsForCraft)
            {
                if(itemForCraft.m_name != item.m_name || itemForCraft.type != item.type)
                {
                    Debug.Log($"Item {itemForCraft.m_name} doesn't fits for that alchemy recipe");
                    return null;
                }
            }
        }

        return result;
    }
}
