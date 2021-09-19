using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private Transform itemContainer;
    private Transform itemTemplate;
    private Inventory inventory;
    private PlayerController player;

    private void Awake()
    {
        itemContainer = transform.Find("itemContainer");
        itemTemplate = itemContainer.Find("itemTemplate");
    }

    public void SetPlayer(PlayerController player)
    {
        this.player = player;
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemsChange += Inventory_OnItemsChange;
        RefreshInventoryUI();
    }

    private void Inventory_OnItemsChange(object sender, System.EventArgs e)
    {
        RefreshInventoryUI();
    }

    public void RefreshInventoryUI()
    {
        foreach(Transform child in itemContainer)
        {
            if (child == itemTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        float size = 5.5f;
        foreach(var item in inventory.GetAllItems())
        {
            var newInventoryItem = Instantiate(itemTemplate, itemContainer).GetComponent<RectTransform>();
            newInventoryItem.anchoredPosition = new Vector2(x * size, 0);
            newInventoryItem.GetComponent<Image>().sprite = item.sprite;
            //newInventoryItem.GetComponent<Button>().onClick.AddListener(() => inventory.UseItem(item));
            newInventoryItem.GetComponent<ItemUIHolder>().item = item;
            newInventoryItem.gameObject.SetActive(true);

            x++;
        }
    }

    private void DropItemFromInventory(Item item)
    {
        inventory.RemoveItem(item);
        ItemWorldSpawner.DropItem(player.GetPosition(), item);
    }
}
