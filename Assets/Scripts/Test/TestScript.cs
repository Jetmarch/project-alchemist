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
        grid = new Grid<AStartGridObject>(5, 5, 5f, new Vector3(-5, -5), (int x, int y, Grid<AStartGridObject> g) => { return new AStartGridObject(x, y, g); });
        startPoint = grid.GetGridObject(0, 0);

        grid.GetGridObject(1, 1).IsWalkable = false;
        grid.GetGridObject(1, 0).IsWalkable = false;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var gridObject = grid.GetGridObject(UtilsClass.GetMouseWorldPosition());
            if(gridObject != null)
            {
                endPoint = gridObject;
            }

            for (int x = 0; x < grid.gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < grid.gridArray.GetLength(1); y++)
                {
                    grid.gridArray[x, y].GValue = 0;
                    grid.gridArray[x, y].HValue = 0;
                    grid.TriggerGridObjectChanged(x, y);
                }
            }

            AStarPath.DoStep(startPoint, endPoint);
        }

        if(Input.GetMouseButtonDown(1))
        {

            var gridObject = grid.GetGridObject(UtilsClass.GetMouseWorldPosition());
            if (gridObject != null)
            {
                gridObject.IsWalkable = !gridObject.IsWalkable;
            }
        }
    }
}

public class AStartGridObject
{
    public int x;
    public int y;
    private int gValue;
    private int hValue;
    private int fValue;
    private bool isWalkable;


    public int GValue
    {
        set
        {
            gValue = value;
            grid.TriggerGridObjectChanged(this.x, this.y);
        }
        get
        {
            return gValue;
        }
    } //Стоимость перехода от начальной точки
    public int HValue 
    {
        set
        {
            hValue = value;
            grid.TriggerGridObjectChanged(this.x, this.y);
        }
        get
        {
            return hValue;
        }
    } //Эвристическая стоимость достижения конечной точки
    public int FValue
    {
        set
        {
            fValue = value;
            grid.TriggerGridObjectChanged(this.x, this.y);
        }
        get
        {
            return gValue + hValue;
        }
    }

    public bool IsWalkable
    {
        set
        {
            isWalkable = value;
            grid.TriggerGridObjectChanged(this.x, this.y);
        }
        get
        {
            return isWalkable;
        }
    }

    public Grid<AStartGridObject> grid;

    public AStartGridObject(int x, int y, Grid<AStartGridObject> grid)
    {
        this.x = x;
        this.y = y;
        this.grid = grid;
        this.isWalkable = true;
    }

    public int GetFValue()
    {
        return gValue + hValue;
    }

    public override string ToString()
    {
        if (isWalkable)
        {
            return $"{GValue} {HValue} \n {FValue}";
        }
        else
        {
            return "F";
        }
    }

    public static bool operator== (AStartGridObject obj1, AStartGridObject obj2)
    {
        if(ReferenceEquals(obj1, null))
        {
            return false;
        }

        if (ReferenceEquals(obj2, null))
        {
            return false;
        }


        return obj1.x == obj2.x && obj1.y == obj2.y;
    }

    public static bool operator!= (AStartGridObject obj1, AStartGridObject obj2)
    {
        if (ReferenceEquals(obj1, null))
        {
            return false;
        }

        if (ReferenceEquals(obj2, null))
        {
            return true;
        }

        return obj1.x != obj2.x && obj1.y != obj2.y;
    }
}