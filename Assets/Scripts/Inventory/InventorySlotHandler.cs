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
        //TODO: Сделать визуальное обозначение выбранного предмета
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedItem = slot1;
            Debug.Log("Active item: " + selectedItem.item.name);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedItem = slot2;
            Debug.Log("Active item: " + selectedItem.item.name);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedItem = slot3;
            Debug.Log("Active item: " + selectedItem.item.name);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedItem = slot4;
            Debug.Log("Active item: " + selectedItem.item.name);
        }
    }
}
