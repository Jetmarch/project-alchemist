using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryTree
{
    private int countOfLevels;
    private TreeNode root;
    private List<TreeNode> leafs;
    private int maxLevels;
    private int countIdForNodes;
    public BinaryTree(int countOfLevels)
    {
        this.countOfLevels = countOfLevels;
        maxLevels = countOfLevels;
        countIdForNodes = 0;
        root = new TreeNode();
        root.level = 0;
        root.countId = countIdForNodes;
        leafs = new List<TreeNode>();
        GenerateChilds(root);
    }

    private void GenerateChilds(TreeNode parent)
    {
        if(parent.level >= maxLevels)
        {
            leafs.Add(parent);
            return;
        }

        parent.left = new TreeNode() { parent = parent, level = parent.level + 1, countId = countIdForNodes++ };
        parent.right = new TreeNode() { parent = parent, level = parent.level + 1, countId = countIdForNodes++ };
        parent.left.sister = parent.right;
        parent.right.sister = parent.left;

        GenerateChilds(parent.left);
        GenerateChilds(parent.right);
    }
}
