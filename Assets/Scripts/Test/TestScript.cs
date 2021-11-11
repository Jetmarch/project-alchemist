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

        var binaryTree = new BinaryTree(2, (int)(5 * settings.gridCellSize), (int)(5 * settings.gridCellSize), settings.gridCellSize);

        Debug.DrawLine(new Vector3(binaryTree.root.positionOnGrid.x, binaryTree.root.height),
            new Vector3(binaryTree.root.positionOnGrid.x + binaryTree.root.width, binaryTree.root.positionOnGrid.y + binaryTree.root.height), Color.red, 100f);
        Debug.DrawLine(new Vector3(binaryTree.root.width, binaryTree.root.height),
            new Vector3(binaryTree.root.positionOnGrid.x + binaryTree.root.width, binaryTree.root.positionOnGrid.y), Color.red, 100f);
        foreach (var leaf in binaryTree.leafs)
        {
            Debug.Log($"Leaf {leaf.countId} width {leaf.width} height {leaf.height}");
            Debug.DrawLine(new Vector3(leaf.positionOnGrid.x, leaf.positionOnGrid.y, 0), new Vector3(leaf.positionOnGrid.x + leaf.width, leaf.positionOnGrid.y, 0), Color.red, 100f);
            Debug.DrawLine(new Vector3(leaf.positionOnGrid.x, leaf.positionOnGrid.y, 0), new Vector3(leaf.positionOnGrid.x, leaf.positionOnGrid.y + leaf.height, 0), Color.red, 100f);
        }
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