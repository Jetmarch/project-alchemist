using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeNode
{
    public TreeNode parent;
    public TreeNode left;
    public TreeNode right;
    public TreeNode sister;

    public int level;
    public int countId;

    public int width;
    public int height;

    public Vector2Int positionOnGrid;

    public DungeonRoom room;
}
