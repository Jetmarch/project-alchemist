using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotHandler : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;

    [SerializeField] private ItemUIHolder slot1;
    [SerializeField] private ItemUIHolder slot2;
    [SerializeField] private ItemUIHolder slot3;
    [SerializeField] private ItemUIHolder slot4;

    [SerializeField] private GameObject player;

    [SerializeField] private ItemUIHolder selectedItem;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetSlotSelected(slot1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetSlotSelected(slot2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetSlotSelected(slot3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetSlotSelected(slot4);
        }
    }

    void SetSlotSelected(ItemUIHolder slot)
    {
        if (slot == null || slot.item == null)
        {
            return;
        }
        if (selectedItem != null)
        {
            selectedItem.Unselect();
        }

        selectedItem = slot;
        slot.SetSelected();
        Debug.Log("Active item: " + selectedItem.item.name);
    }
}
