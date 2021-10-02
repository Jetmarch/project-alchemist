using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrop : MonoBehaviour, IDropHandler
{
    //TODO: Убрать ссылку на прошлый инвентарь. Предмет при перемещении должен удалять себя сам из прошлого инвентаря
    //И возвращаться в него, если не попал в любой другой инвентарь
    //Ссылка на инвентарь, из которого пришёл предмет
    [SerializeField] private Inventory fromInventory;
    //Ссылка на инвентарь, куда надо добавить новый предмет
    [SerializeField] private Inventory currentInventory;
    public void OnDrop(PointerEventData eventData)
    {
        //Добавляем предмет в котелок и удаляем из инвентаря игрока
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
