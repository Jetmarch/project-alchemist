using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class TestScript : MonoBehaviour
{
    private Grid<AStartGridObject> grid;

    private AStartGridObject startPoint;
    private AStartGridObject endPoint;

    private void Start()
    {
        grid = new Grid<AStartGridObject>(20, 10, 5f, new Vector3(0, 0), (int x, int y, Grid<AStartGridObject> g) => { return new AStartGridObject(x, y, g); });
        startPoint = grid.GetGridObject(0, 0);
        startPoint.gValue = -1;
        grid.SetGridObject(0, 0, startPoint);

        endPoint = grid.GetGridObject(5, 5);
        endPoint.gValue = -1;
        grid.SetGridObject(5, 5, endPoint);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var gridObject = grid.GetGridObject(UtilsClass.GetMouseWorldPosition());
            if(gridObject != null)
            {
                //gridObject.AddValue(5);
            }

            AStarPath.DoStep(startPoint, startPoint, endPoint);
        }

        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetGridObject(UtilsClass.GetMouseWorldPosition()));
        }
    }
}

public class AStartGridObject
{
    public int x;
    public int y;

    public int gValue; //Расстояние до начала
    public int hValue; //Расстояние до конца
    public int fValue; //Сумма расстояний

    public Grid<AStartGridObject> grid;

    public AStartGridObject(int x, int y, Grid<AStartGridObject> grid)
    {
        this.x = x;
        this.y = y;
        this.grid = grid;
    }

    public int GetFValue()
    {
        return gValue + hValue;
    }

    public override string ToString()
    {
        return $"{gValue} {hValue} \n {GetFValue()}";
    }
}