using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AStarPath
{
    public static void DoStep(AStartGridObject startPoint, AStartGridObject endPoint)
    {
        List<AStartGridObject> openList = new List<AStartGridObject>();
        List<AStartGridObject> closedList = new List<AStartGridObject>();

        AStartGridObject current = startPoint;
        openList.Add(current);
        current.HValue = HeuristicFunc(startPoint, endPoint);

        while (openList.Count() > 0)
        {
            if (current == endPoint)
            {
                Debug.Log("Path complete");
                return;
            }
            //Создание сетки и попытка достичь конечной точки
            var validSuccesors = new List<AStartGridObject>();
            var succesors = GetSuccessors(current);
            foreach (var item in succesors)
            {
                if (!closedList.Contains(item))
                {
                    validSuccesors.Add(item);
                }
            }

            var nextNode = validSuccesors.Count() > 0 ? validSuccesors[0] : null;
            foreach (var item in validSuccesors)
            {
                if (closedList.Contains(item))
                {
                    continue;
                }


                item.GValue = current.GValue + 1;
                item.HValue = HeuristicFunc(item, endPoint);
                openList.Add(item);
                if (nextNode.FValue > item.FValue)
                {
                    nextNode = item;
                }

                if (nextNode.HValue > item.HValue && nextNode.FValue == item.FValue)
                {
                    nextNode = item;
                }
            }

            openList.Remove(current);
            closedList.Add(current);

            current = nextNode;
            Debug.Log($"Current item X={current.x} Y={current.y} Walkable={current.IsWalkable}");
        }

        //Возвращение из конечной точки в начальную самым "дешёвым" путём


    }
   

    public static List<AStartGridObject> UpdateWeigths(AStartGridObject gridObject, AStartGridObject startPoint, AStartGridObject endPoint)
    {
        Vector2 startPointCoord = new Vector2(startPoint.x, startPoint.y);
        Vector2 endPointCoord = new Vector2(endPoint.x, endPoint.y);

        var neighbors = GetSuccessors(gridObject);

        foreach(var obj in neighbors)
        {
            CalculateGridObjectWeightsAndUpdate(obj, startPointCoord, endPointCoord);
        }

        return neighbors;
    }

    private static int HeuristicFunc(AStartGridObject obj1, AStartGridObject obj2)
    {
        return Mathf.Abs(obj1.x - obj2.x) + Mathf.Abs(obj1.y - obj2.y);
    }

    private static int CalculateDistanceBetweenNods(AStartGridObject nodeOne, AStartGridObject nodeTwo)
    {
        Vector2 nodeOneVec = new Vector2(nodeOne.x, nodeOne.y);
        Vector2 nodeTwoVec = new Vector2(nodeTwo.x, nodeTwo.y);

        return Mathf.RoundToInt(Vector2.Distance(nodeOneVec, nodeTwoVec));
    }

    private static void CalculateGridObjectWeightsAndUpdate(AStartGridObject gridObject, Vector2 startPointCoord, Vector2 endPointCoord)
    {
        Vector2 gridObjectCoord = new Vector2(gridObject.x, gridObject.y);
        int gValue = Mathf.FloorToInt(Vector2.Distance(gridObjectCoord, startPointCoord));
        int hValue = Mathf.FloorToInt(Vector2.Distance(gridObjectCoord, endPointCoord));
        gridObject.GValue = gValue;
        gridObject.HValue = hValue;
        gridObject.grid.TriggerGridObjectChanged(gridObject.x, gridObject.y);
    }

    private static List<AStartGridObject> GetSuccessors(AStartGridObject gridObject)
    {
        var upObject = gridObject.grid.GetGridObject(gridObject.x, gridObject.y + 1);
        var downObject = gridObject.grid.GetGridObject(gridObject.x, gridObject.y - 1);
        var leftObject = gridObject.grid.GetGridObject(gridObject.x - 1, gridObject.y);
        var rightObject = gridObject.grid.GetGridObject(gridObject.x + 1, gridObject.y);

        var neighbors = new List<AStartGridObject>();
        if(upObject != null && upObject.IsWalkable) neighbors.Add(upObject);
        if(downObject != null && downObject.IsWalkable) neighbors.Add(downObject);
        if(leftObject != null && leftObject.IsWalkable) neighbors.Add(leftObject);
        if(rightObject != null && rightObject.IsWalkable) neighbors.Add(rightObject);

        return neighbors;
    }
}
