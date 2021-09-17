using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public static ItemWorld SpawnItem(Vector3 position, Item item)
    {
        ItemWorld itemWorld = Instantiate(AssetManager.Instance.itemWorldTemplate, position, Quaternion.identity).GetComponent<ItemWorld>();
        item.sprite = AssetManager.Instance.GetSpriteForItem(item.type);
        itemWorld.SetItem(item);

        return itemWorld;
    }

    public static ItemWorld DropItem(Vector3 position, Item item)
    {
        Vector3 testOffset = new Vector3(2.0f, 0.0f);
        ItemWorld itemWorld = SpawnItem(position + testOffset, item);
        return itemWorld;
    }
}
