using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator 
{
    private Grid<int> grid;
    private BinaryTree dungeonTree;

    private const float MIN_ROOM_HEIGHT = 1f;
    private const float MIN_ROOM_WIDTH = 1f;

    public DungeonGenerator()
    {

    }

    public void GenerateDungeon(int widthInCells, int heightInCells, int gridCellSize, int countOfRooms)
    {
        grid = new Grid<int>(widthInCells, heightInCells, gridCellSize, Vector3.zero, (int x, int y, Grid<int> g) => 0);

        //TODO: Автоматически подгонять количество комнат под ближайший корень из 2
        int countOfBinaryTreeLevelBasedOnRoomCount = (int)Mathf.Sqrt(countOfRooms);
        dungeonTree = new BinaryTree(countOfBinaryTreeLevelBasedOnRoomCount, widthInCells, heightInCells, gridCellSize);
        GenerateRoomsInLeafsOfBinaryTree(dungeonTree);
    }

    private void GenerateRoomsInLeafsOfBinaryTree(BinaryTree tree)
    {
        foreach(var leaf in tree.leafs)
        {
            GenerateRoomInLeaf(leaf);
        }
    }

    private void GenerateRoomInLeaf(TreeNode node)
    {
        node.room = new DungeonRoom();
        float roomHeight = Random.Range(MIN_ROOM_HEIGHT, node.height);
        float roomWidth = Random.Range(MIN_ROOM_WIDTH, node.width);
        float roomX = Random.Range(node.positionOnGrid.x, node.positionOnGrid.x + node.width);
        float roomY = Random.Range(node.positionOnGrid.y, node.positionOnGrid.y + node.height);
    }
}
