using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : MonoBehaviour
{
    public static AssetManager Instance { get; private set; }

    public AssetManager()
    {
        Instance = this;
    }

    public GameObject itemWorldTemplate;

    public Sprite knob;
    public Sprite tile;

    public Sprite GetSpriteForItem(ItemType type)
    {
        if (type == ItemType.Knob)
            return knob;
        if (type == ItemType.Tile)
            return tile;

        return null;
    }
}
