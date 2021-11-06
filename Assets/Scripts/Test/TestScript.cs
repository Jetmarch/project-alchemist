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
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            //pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            //List<PathNode> path = pathfinding.FindPath(0, 0, x, y);
            //if (path != null)
            //{
            //    for (int i = 0; i < path.Count - 1; i++)
            //    {
            //        Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 2.5f + Vector3.one * 1.25f, new Vector3(path[i+1].x, path[i+1].y) * 2.5f + Vector3.one * 1.25f, Color.red, 2, false);
            //    }
            //}
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