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

    [SerializeField] private PlayerController player;

    [SerializeField] private ItemUIHolder selectedItem;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ToggleSlot(slot1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ToggleSlot(slot2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ToggleSlot(slot3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ToggleSlot(slot4);
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(selectedItem == null)
            {
                return;
            }

            player.ThrowItem(selectedItem.item);
            selectedItem.Unselect();
            selectedItem = null;
        }

        if(Input.GetMouseButtonDown(1))
        {
            if (selectedItem == null)
            {
                return;
            }

            player.UseItem(selectedItem.item);
            selectedItem.Unselect();
            selectedItem = null;
        }
    }

    void ToggleSlot(ItemUIHolder slot)
    {
        if (slot == null || slot.item == null)
        {
            return;
        }
        if (selectedItem != null)
        {
            selectedItem.Unselect();
        }
        if(selectedItem == slot)
        {
            selectedItem = null;
            return;
        }

        selectedItem = slot;
        slot.SetSelected();
        Debug.Log("Active item: " + selectedItem.item.name);
    }
}
