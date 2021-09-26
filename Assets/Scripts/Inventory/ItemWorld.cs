using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public Item item;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetItem(item);
    }

    public void SetItem(Item item)
    {
        Debug.Log("SetItem item sprite" + item.sprite);
        this.item = item;

        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = item.sprite;
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
