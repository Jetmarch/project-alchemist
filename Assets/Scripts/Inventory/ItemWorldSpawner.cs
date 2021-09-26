using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public static GameObject SpawnItem(Vector3 position, Item item)
    {
        GameObject itemWorld = Instantiate(AssetManager.Instance.itemWorldTemplate, position, Quaternion.identity);
        itemWorld.GetComponent<ItemWorld>().SetItem(item);

        return itemWorld;
    }

    public static GameObject SpawnThrowableItem(Vector3 position, Item item)
    {
        GameObject itemWorld = Instantiate(AssetManager.Instance.itemWorldTemplateThrowable, position, Quaternion.identity);
        itemWorld.GetComponent<ItemWorld>().SetItem(item);

        return itemWorld;
    }

    public static GameObject DropItem(Vector3 position, Item item)
    {
        Vector3 testOffset = new Vector3(2.0f, 0.0f);
        GameObject itemWorld = SpawnItem(position + testOffset, item);
        return itemWorld;
    }
}
