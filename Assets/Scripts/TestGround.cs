using System.Collections;
using System.Collections.Generic;
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
            player.AddItemToInventory(ItemFactory.instance.CreateIngredientFlowerOfTheGod());
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            player.inventory.items[0].Use(this.gameObject, player.inventory.items[0]);
        }
    }
}
