using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestGround : MonoBehaviour
{
    private PlayerController player;

    private void Start()
    {
        player = GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            player.AddItemToInventory(ItemFactory.instance.CreateMagicItem());
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if (player.inventory.items.ElementAtOrDefault(1) != null)
            {
                Debug.Log(player.inventory.items[0]);
                player.inventory.items[0].Use(this.gameObject, player.inventory.items[0]);
            }
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (player.inventory.items.ElementAtOrDefault(1) != null)
            {
                Debug.Log(player.inventory.items[0]);
                player.inventory.items[1].Use(this.gameObject, player.inventory.items[0]);
            }
        }
    }
}
