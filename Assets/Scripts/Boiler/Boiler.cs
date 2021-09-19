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

    }
}
