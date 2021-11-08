using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator 
{
    private Grid<int> grid;
    private BinaryTree dungeonTree;

    private const int MIN_ROOM_HEIGHT = 1;
    private const int MIN_ROOM_WIDTH = 1;

    public DungeonGenerator()
    {

    }

    public void GenerateDungeon(int widthInCells, int heightInCells, int countOfRooms)
    {
        grid = new Grid<int>(widthInCells, heightInCells, 2.5f, Vector3.zero, (int x, int y, Grid<int> g) => 0);

        //TODO: Автоматически подгонять количество комнат под ближайший корень из 2
        int countOfBinaryTreeLevelBasedOnRoomCount = (int)Mathf.Sqrt(countOfRooms);
        dungeonTree = new BinaryTree(countOfBinaryTreeLevelBasedOnRoomCount, widthInCells, heightInCells);
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
        int roomHeight = Random.Range(MIN_ROOM_HEIGHT, node.height);
        int roomWidth = Random.Range(MIN_ROOM_WIDTH, node.width);
        int roomX = Random.Range(node.positionOnGrid.x, node.positionOnGrid.x + node.width);
        int roomY = Random.Range(node.positionOnGrid.y, node.positionOnGrid.y + node.height);
    }
}
