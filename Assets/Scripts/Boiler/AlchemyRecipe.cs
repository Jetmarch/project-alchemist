using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class AlchemyRecipe : ScriptableObject
{
    public List<Item> materials;
    public List<Item> result;

    public List<Item> Craft(List<Item> materialsForCraft)
    {
        //Ќаходим различи€ в листах с материалами
        //≈сли есть хоть одно, то ничего не возвращаем
        if(materials.Except(materialsForCraft).Any())
        {
            return null;
        }

        return result;
    }
}
