using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boiler : MonoBehaviour
{
    List<Item> currentItemsForBoiling;

    private void Awake()
    {
        currentItemsForBoiling = new List<Item>();
    }

    public bool AddItemForBoiling(Item item)
    {
        //TODO: добавить возможность смешивать не только ингредиенты, но и зель€
        if(item.type == ItemType.Ingredient)
        {
            currentItemsForBoiling.Add(item);
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// ѕроизводит варку с текущими предметами из currentItemsForBoiling
    /// TODO: ѕридумать способ хранени€ всех рецептов дл€ варки и их удобной переборки
    /// </summary>
    public void Boiling()
    {

    }
}
