using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="PickableItem", menuName ="ScriptableObjects/PickableItem", order = 1)]
public class PickableItem : ScriptableObject
{
    public string itemName;
    public string description;
}
