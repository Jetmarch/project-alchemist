using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrop : MonoBehaviour, IDropHandler
{
    //TODO: ������ ������ �� ������� ���������. ������� ��� ����������� ������ ������� ���� ��� �� �������� ���������
    //� ������������ � ����, ���� �� ����� � ����� ������ ���������
    //������ �� ���������, �� �������� ������ �������
    [SerializeField] private Inventory fromInventory;
    //������ �� ���������, ���� ���� �������� ����� �������
    [SerializeField] private Inventory currentInventory;
    public void OnDrop(PointerEventData eventData)
    {
        //��������� ������� � ������� � ������� �� ��������� ������
        if(eventData.pointerDrag != null)
        {
            Item item = eventData.pointerDrag.GetComponent<ItemUIHolder>().item;
            if(currentInventory.AddItem(item))
            {
                fromInventory.RemoveItem(item);
            }

            eventData.pointerDrag.GetComponent<ItemDrag>().ReturnToInventoryPosition();
        }
    }
}
