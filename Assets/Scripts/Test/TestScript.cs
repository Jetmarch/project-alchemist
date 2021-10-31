using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class TestScript : MonoBehaviour
{
    private Grid<TestGridObject> grid;

    private void Start()
    {
        grid = new Grid<TestGridObject>(20, 10, 5f, new Vector3(0, 0), (int x, int y, Grid<TestGridObject> g) => { return new TestGridObject(x, y, g); });
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var gridObject = grid.GetGridObject(UtilsClass.GetMouseWorldPosition());
            if(gridObject != null)
            {
                gridObject.AddValue(5);
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetGridObject(UtilsClass.GetMouseWorldPosition()));
        }
    }
}

public class TestGridObject
{
    private const int MAX_VALUE = 100;
    private const int MIN_VALUE = 0;
    private int value;
    private int x;
    private int y;
    private Grid<TestGridObject> grid;
    public TestGridObject(int x, int y, Grid<TestGridObject> grid)
    {
        this.x = x;
        this.y = y;
        this.grid = grid;
    }

    public void AddValue(int addValue)
    {
        value += addValue;
        value = Mathf.Clamp(value, MIN_VALUE, MAX_VALUE);
        grid.TriggerGridObjectChanged(x, y);
    }

    public override string ToString()
    {
        return value.ToString();
    }
}