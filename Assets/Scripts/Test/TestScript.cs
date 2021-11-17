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
        //pathfinding = new AStarPath(5, 5, settings.gridCellSize);

        var dungeonGenerator = new DungeonGenerator();
        dungeonGenerator.GenerateDungeon(20, 20, settings.gridCellSize, 1);

       // var binaryTree = new BinaryTree(2, 5 * settings.gridCellSize, 5 * settings.gridCellSize, settings.gridCellSize);
       // binaryTree.DrawDebugLines();
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