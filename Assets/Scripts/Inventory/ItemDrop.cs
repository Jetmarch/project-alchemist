using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        
        if(eventData.pointerDrag != null)
        {
            Item item = eventData.pointerDrag.GetComponent<ItemUIHolder>().item;
            Debug.Log("Boiled ingredient " + item.m_name);
            Destroy(eventData.pointerDrag.gameObject);
        }
    }
}
