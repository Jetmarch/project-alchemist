using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        //��������� ������� � ������� � ������� �� ��������� ������
        if(eventData.pointerDrag != null)
        {
            Item item = eventData.pointerDrag.GetComponent<ItemUIHolder>().item;
            if(GetComponent<Boiler>().AddItemForBoiling(item))
            {
                GameObject.Find("Player").GetComponent<PlayerController>().inventory.RemoveItem(item);
                Destroy(eventData.pointerDrag.gameObject);
            }
            else
            {
                eventData.pointerDrag.GetComponent<ItemDrag>().ReturnToInventoryPosition();
            }
        }
    }
}
