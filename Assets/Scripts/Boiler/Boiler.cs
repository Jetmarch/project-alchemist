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
    /// </summary>
    public void Boiling()
    {
        foreach(var recipe in alchemyRecipes)
        {
            List<Item> result = recipe.Craft(currentItemsForBoiling);
            if(result != null)
            {
                //�� ������� ���������, � ������� ������ ��, ��� �������������� � ������
                //���� ������� ����� ������ ����� Craft � �������
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
        //TODO: ����������� ��� �������� ������, ���� ��������� ��� �����
        foreach(var item in currentItemsForBoiling)
        {
            inventory.AddItem(item);
        }
        currentItemsForBoiling.Clear();
    }
}
