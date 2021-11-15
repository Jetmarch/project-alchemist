using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryTree
{
    public int countOfLevels;
    public TreeNode root;
    public List<TreeNode> leafs;
    private int maxLevels;
    private int countIdForNodes;
    private int gridCellSize;

    private const int MIN_PROCENT_OF_CELL_AREA = 30;
    private const int MAX_PROCENT_OF_CELL_AREA = 70;

    public BinaryTree(int countOfLevels, int width, int height, int gridCellSize)
    {
        this.countOfLevels = countOfLevels;
        this.maxLevels = countOfLevels;
        this.countIdForNodes = 0;
        this.gridCellSize = gridCellSize;
        root = new TreeNode();
        root.level = 0;
        root.countId = countIdForNodes;
        root.width = width * gridCellSize;
        root.height = height * gridCellSize;
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
            float modifiedWidth = Mathf.RoundToInt(Random.Range(parent.width / 100 * MIN_PROCENT_OF_CELL_AREA, parent.width / 100 * MAX_PROCENT_OF_CELL_AREA));
            modifiedWidth = modifiedWidth - (modifiedWidth % gridCellSize);

            parent.left.width = modifiedWidth;
            parent.left.height = parent.height;

            parent.right.width = parent.width - modifiedWidth;
            parent.right.height = parent.height;

            parent.left.positionOnGrid.y = parent.positionOnGrid.y;
            parent.right.positionOnGrid.y = parent.positionOnGrid.y;
            parent.left.positionOnGrid.x = parent.positionOnGrid.x;
            parent.right.positionOnGrid.x = parent.positionOnGrid.x + parent.left.width;

        }
        else
        {
            float modifiedHeight = Mathf.RoundToInt(Random.Range(parent.height / 100 * MIN_PROCENT_OF_CELL_AREA, parent.height / 100 * MAX_PROCENT_OF_CELL_AREA));
            modifiedHeight = modifiedHeight - (modifiedHeight % gridCellSize);

            parent.left.height = modifiedHeight;
            parent.left.width = parent.width;

            parent.right.height = parent.height - modifiedHeight;
            parent.right.width = parent.width;

            parent.left.positionOnGrid.x = parent.positionOnGrid.x;
            parent.right.positionOnGrid.x = parent.positionOnGrid.x;
            parent.left.positionOnGrid.y = parent.positionOnGrid.y;
            parent.right.positionOnGrid.y = parent.positionOnGrid.y + parent.left.height;

        }
    }

    private void RandomRoomInLeaf(TreeNode node)
    {

    }

    public void DrawDebugLines()
    {
       // Debug.DrawLine(new Vector3(root.positionOnGrid.x  , root.height ),
        //    new Vector3(root.positionOnGrid.x + root.width, root.positionOnGrid.y + root.height), Color.red, 100f);
        //Debug.DrawLine(new Vector3(root.width, root.height),
        //    new Vector3(root.positionOnGrid.x + root.width, root.positionOnGrid.y), Color.red, 100f);
        foreach (var leaf in leafs)
        {
            var room = leaf.room;
           // Debug.DrawLine(new Vector3(leaf.positionOnGrid.x, leaf.positionOnGrid.y, 0), new Vector3(leaf.positionOnGrid.x + leaf.width, leaf.positionOnGrid.y, 0), Color.red, 100f);
          //  Debug.DrawLine(new Vector3(leaf.positionOnGrid.x, leaf.positionOnGrid.y, 0), new Vector3(leaf.positionOnGrid.x, leaf.positionOnGrid.y + leaf.height, 0), Color.red, 100f);


           /* Debug.DrawLine(new Vector3(room.position.x , room.height),
            new Vector3(room.position.x + room.width, room.position.y + room.height), Color.green, 100f);
            Debug.DrawLine(new Vector3(room.width, room.height),
                new Vector3(room.position.x + room.width, room.position.y), Color.green, 100f);*/
            Debug.DrawLine(new Vector3(room.position.x * gridCellSize, room.position.y * gridCellSize, 0),
                new Vector3(room.position.x * gridCellSize + room.width * gridCellSize, room.position.y * gridCellSize, 0), Color.green, 100f);
            Debug.DrawLine(new Vector3(room.position.x * gridCellSize, room.position.y * gridCellSize, 0),
                new Vector3(room.position.x * gridCellSize, room.position.y * gridCellSize + room.height * gridCellSize, 0), Color.green, 100f);
        }
    }
}
