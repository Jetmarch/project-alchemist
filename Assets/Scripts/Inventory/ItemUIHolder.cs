using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIHolder : MonoBehaviour
{
    public Item item;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        image.sprite = item.sprite;
    }

    public void ClearSlot()
    {
        this.item = null;
        image.sprite = null;
    }
}
