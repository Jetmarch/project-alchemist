using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotHandler : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1");
        }
    }
}
