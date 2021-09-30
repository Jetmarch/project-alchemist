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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
        }
    }
}
