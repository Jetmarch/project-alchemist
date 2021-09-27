using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private Transform itemContainer;
    private Transform itemTemplate;
    [SerializeField] private Inventory inventory;
    private PlayerController player;

    private void Awake()
    {
        itemContainer = transform.Find("itemContainer");
        itemTemplate = itemContainer.Find("itemTemplate");
        player = FindObjectOfType<PlayerController>();
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
            if(item == null)
            {
                Debug.Log("Some item in inventory is null");
                return;
            }
            var newInventoryItem = Instantiate(itemTemplate, itemContainer).GetComponent<RectTransform>();
            newInventoryItem.anchoredPosition = new Vector2(x * size, 0);
            newInventoryItem.GetComponent<Image>().sprite = item.sprite;
            newInventoryItem.GetComponent<Button>().onClick.AddListener(() => player.ThrowItem(item));
            newInventoryItem.GetComponent<ItemUIHolder>().item = item;
            newInventoryItem.gameObject.SetActive(true);

            x++;
        }
    }
}
