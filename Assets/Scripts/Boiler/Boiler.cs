using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boiler : MonoBehaviour
{
    [SerializeField] private List<Item> currentItemsForBoiling;
    [SerializeField] private List<AlchemyRecipe> alchemyRecipes;
    

    private void Awake()
    {
        currentItemsForBoiling = new List<Item>();
    }

    public bool AddItemForBoiling(Item item)
    {
        //TODO: �������� ����������� ��������� �� ������ �����������, �� � �����
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
    /// ���������� ����� � �������� ���������� �� currentItemsForBoiling
    /// TODO: ��������� ������ �������� ���� �������� ��� ����� � �� ������� ���������
    /// </summary>
    public void Boiling()
    {
        foreach(var recipe in alchemyRecipes)
        {
            List<Item> result = recipe.Craft(currentItemsForBoiling);
            if(result != null)
            {
                currentItemsForBoiling.Clear();
                foreach(var item in result)
                {
                    GameObject.Find("Player").GetComponent<PlayerController>().inventory.AddItem(item);
                    Debug.Log($"Crafted: {item.m_name}!");
                }
                return;
            }
        }

        Debug.Log("Nothing to craft with this ingredients");
    }

    public void ClearBoiler()
    {
        foreach(var item in currentItemsForBoiling)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().inventory.AddItem(item);
        }
        currentItemsForBoiling.Clear();
    }
}
