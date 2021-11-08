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
    public BinaryTree(int countOfLevels, int width, int height)
    {
        this.countOfLevels = countOfLevels;
        maxLevels = countOfLevels;
        countIdForNodes = 0;
        root = new TreeNode();
        root.level = 0;
        root.countId = countIdForNodes;
        root.width = width;
        root.height = height;
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

        RandomSizeOfChildNodes(parent);

        GenerateChilds(parent.left);
        GenerateChilds(parent.right);
    }

    private void RandomSizeOfChildNodes(TreeNode parent)
    {
        //¬ыбор по какой стороне будет происходить разделение дочерних элементов
        bool isRandomWidth = false;
        isRandomWidth = Random.value >= 0.5 ? true : false;

        if (isRandomWidth)
        {
            int modifiedWidth = parent.width;
            modifiedWidth = modifiedWidth / (int)Random.Range(2f, 5f);

            if (Random.Range(0, 100) >= 50)
            {
                parent.left.width = modifiedWidth;
                parent.left.height = parent.height;

                parent.right.width = parent.width - modifiedWidth;
                parent.right.height = parent.height;
            }
            else
            {
                parent.right.width = modifiedWidth;
                parent.right.height = parent.height;

                parent.left.width = parent.width - modifiedWidth;
                parent.left.height = parent.height;
            }
        }
        else
        {
            int modifiedHeight = parent.height;
            modifiedHeight = modifiedHeight / (int)Random.Range(2f, 5f);

            if (Random.Range(0, 100) >= 50)
            {
                parent.left.height = modifiedHeight;
                parent.left.width = parent.width;

                parent.right.height = parent.height - modifiedHeight;
                parent.right.width = parent.width;
            }
            else
            {
                parent.right.height = modifiedHeight;
                parent.right.width = parent.width;

                parent.left.height = parent.height - modifiedHeight;
                parent.left.width = parent.width;
            }
        }
    }

    private void RandomRoomInLeaf(TreeNode node)
    {

    }
}
