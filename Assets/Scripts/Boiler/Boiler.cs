using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boiler : MonoBehaviour
{
    [SerializeField] private List<Item> currentItemsForBoiling;

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
        Debug.Log("Boiling...");
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
