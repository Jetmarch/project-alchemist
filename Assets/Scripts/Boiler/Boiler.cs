using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boiler : MonoBehaviour
{
    [SerializeField] private List<Item> currentItemsForBoiling;
    [SerializeField] private List<AlchemyRecipe> alchemyRecipes;
    [SerializeField] private Inventory inventory;
    

    private void Awake()
    {
        currentItemsForBoiling = new List<Item>();
    }

    public bool AddItemForBoiling(Item item)
    {
        if(item == null)
        {
            return false;
        }
        //TODO: добавить возможность смешивать не только ингредиенты, но и зелья
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
    /// Производит варку с текущими предметами из currentItemsForBoiling
    /// </summary>
    public void Boiling()
    {
        foreach(var recipe in alchemyRecipes)
        {
            List<Item> result = recipe.Craft(currentItemsForBoiling);
            if(result != null)
            {
                //Не очищать полностью, а убирать только те, что использовались в крафте
                //Либо сделать более точный метод Craft у рецепта
                currentItemsForBoiling.Clear();
                foreach(var item in result)
                {
                    inventory.AddItem(item);
                    Debug.Log($"Crafted: {item.m_name}!");
                }
                return;
            }
        }

        Debug.Log("Nothing to craft with this ingredients");
    }

    public void ClearBoiler()
    {
        //TODO: Выбрасывать все предметы наружу, если инвентарь уже забит
        foreach(var item in currentItemsForBoiling)
        {
            inventory.AddItem(item);
        }
        currentItemsForBoiling.Clear();
    }
}
