using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public Item item;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetItem(item);
    }

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.sprite;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
