using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class TestScript : MonoBehaviour
{
    private AStarPath pathfinding;

    private void Start()
    {
        pathfinding = new AStarPath(5, 5); 
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            int x, y;
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPosition, out x, out y);
            List<PathNode> path = pathfinding.FindPath(0, 0, x, y);
            if (path != null)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 5f + Vector3.one * 2.5f, new Vector3(path[i+1].x, path[i+1].y) * 5f + Vector3.one * 2.5f, Color.red, 2, false);
                }
            }
        }

        if(Input.GetMouseButtonDown(1))
        {

        }
    }
}