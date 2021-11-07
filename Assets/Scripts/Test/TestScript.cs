using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class TestScript : MonoBehaviour
{
    private AStarPath pathfinding;

    [SerializeField]
    private SettingsManager settings;

    private void Start()
    {
        pathfinding = new AStarPath(5, 5, settings.gridCellSize);

        var binaryTree = new BinaryTree(3, 20, 20);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           
        }

        if(Input.GetMouseButtonDown(1))
        {
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            var node = pathfinding.GetGrid().GetGridObject(x, y);
            node.walkable = !node.walkable;
        }
    }
}