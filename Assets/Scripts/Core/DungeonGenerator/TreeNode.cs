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

    public float width;
    public float height;

    public Vector2 positionOnGrid;

    public DungeonRoom room;
}
