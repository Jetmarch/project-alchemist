using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    private Grid<PathNode> grid;

    private int _x;
    private int _y;
    private bool _walkable;

    private int _gCost;
    private int _hCost;
    private int _fCost;


    public int x
    {
        set
        {
            _x = value;
            grid.TriggerGridObjectChanged(_x, _y);
        }
        get
        {
            return _x;
        }
    }

    public int y
    {
        set
        {
            _y = value;
            grid.TriggerGridObjectChanged(_x, _y);
        }
        get
        {
            return _y;
        }
    }

    public bool walkable
    {
        set
        {
            _walkable = value;
            grid.TriggerGridObjectChanged(_x, _y);
        }
        get
        {
            return _walkable;
        }
    }

    public int gCost
    {
        set
        {
            _gCost = value;
            grid.TriggerGridObjectChanged(_x, _y);
        }
        get
        {
            return _gCost;
        }
    }
    public int hCost
    {
        set
        {
            _hCost = value;
            grid.TriggerGridObjectChanged(_x, _y);
        }
        get
        {
            return _hCost;
        }
    }
    public int fCost
    {
        set
        {
            _fCost = value;
            grid.TriggerGridObjectChanged(_x, _y);
        }
        get
        {
            return _fCost;
        }
    }

    public PathNode cameFromNode;

    public PathNode(int x, int y, bool walkable, Grid<PathNode> grid)
    {
        this._x = x;
        this._y = y;
        this.grid = grid;
        this._walkable = walkable;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public override string ToString()
    {
        if (walkable)
        {
            return "";
        }
        else
        {
            return "WALL";
        }
    }
}
