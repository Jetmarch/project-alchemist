using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AStarPath
{

    public static AStartGridObject DoStep(AStartGridObject gridObject, AStartGridObject startPoint, AStartGridObject endPoint)
    {
        var neighborsGridObjects = UpdateWeigths(gridObject, startPoint, endPoint);
        var nextGridObject = neighborsGridObjects[0];
        List<AStartGridObject> stepTwo = new List<AStartGridObject>();

        foreach(var x in neighborsGridObjects)
        {
            foreach(var y in neighborsGridObjects)
            {
                if(x.GetFValue() < y.GetFValue())
                {
                    nextGridObject = x;
                }
                else if(x.GetFValue() == y.GetFValue())
                {
                    stepTwo.Add(x);
                    stepTwo.Add(y);
                }
            }
        }

        if(stepTwo.Count() == 0)
        {
            return nextGridObject;
        }

        return null;
    }
   

    public static List<AStartGridObject> UpdateWeigths(AStartGridObject gridObject, AStartGridObject startPoint, AStartGridObject endPoint)
    {
        Vector2 startPointCoord = new Vector2(startPoint.x, startPoint.y);
        Vector2 endPointCoord = new Vector2(endPoint.x, endPoint.y);

        var neighbors = GetNeighbors(gridObject);

        foreach(var obj in neighbors)
        {
            CalculateGridObjectWeightsAndUpdate(obj, startPointCoord, endPointCoord);
        }

        return neighbors;
    }

    private static void CalculateGridObjectWeightsAndUpdate(AStartGridObject gridObject, Vector2 startPointCoord, Vector2 endPointCoord)
    {
        Vector2 gridObjectCoord = new Vector2(gridObject.x, gridObject.y);
        int gValue = Mathf.FloorToInt(Vector2.Distance(gridObjectCoord, startPointCoord));
        int hValue = Mathf.FloorToInt(Vector2.Distance(gridObjectCoord, endPointCoord));
        gridObject.gValue = gValue;
        gridObject.hValue = hValue;
        gridObject.grid.TriggerGridObjectChanged(gridObject.x, gridObject.y);
    }

    private static List<AStartGridObject> GetNeighbors(AStartGridObject gridObject)
    {
        var upObject = gridObject.grid.GetGridObject(gridObject.x, gridObject.y + 1);
        var downObject = gridObject.grid.GetGridObject(gridObject.x, gridObject.y - 1);
        var leftObject = gridObject.grid.GetGridObject(gridObject.x - 1, gridObject.y);
        var rightObject = gridObject.grid.GetGridObject(gridObject.x + 1, gridObject.y);

        var neighbors = new List<AStartGridObject>();
        if(upObject != null) neighbors.Add(upObject);
        if(downObject != null) neighbors.Add(downObject);
        if(leftObject != null) neighbors.Add(leftObject);
        if(rightObject != null) neighbors.Add(rightObject);

        return neighbors;
    }
}
