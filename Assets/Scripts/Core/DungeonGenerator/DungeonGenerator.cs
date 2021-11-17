using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator 
{
    private Grid<int> grid;
    private BinaryTree dungeonTree;
    private AStarPath pathfinding;
    private int gridCellSize;

    private const float MIN_ROOM_HEIGHT = 2f;
    private const float MIN_ROOM_WIDTH = 2f;

    public DungeonGenerator()
    {

    }

    public void GenerateDungeon(int widthInCells, int heightInCells, int gridCellSize, int countOfRooms)
    {
        this.gridCellSize = gridCellSize;
        //Общая сетка, содержащая в себе всю информацию о тайле
        grid = new Grid<int>(widthInCells, heightInCells, gridCellSize, Vector3.zero, (int x, int y, bool isWall, Grid<int> g) => 0, true, false);

        //TODO: Автоматически подгонять количество комнат под ближайший корень из 2
        int countOfBinaryTreeLevelBasedOnRoomCount = countOfRooms;
        dungeonTree = new BinaryTree(countOfBinaryTreeLevelBasedOnRoomCount, widthInCells, heightInCells, gridCellSize);
        
        GenerateRoomsInLeafsOfBinaryTree(dungeonTree);

        pathfinding = new AStarPath(widthInCells, heightInCells, gridCellSize);
        

        //После генерации дерева с комнатами и переходами внутри, начинается модификация основного Grid

        ModificateGridWithDungeonTree();
        dungeonTree.DrawDebugLines();
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

        //TODO: Генерация комнат в рандомном процентном соотношении от площади TreeNode
        float roomHeight = Random.Range(MIN_ROOM_HEIGHT, node.height);
        float roomWidth = Random.Range(MIN_ROOM_WIDTH, node.width);
        float roomX = Random.Range(node.positionOnGrid.x, node.width);
        float roomY = Random.Range(node.positionOnGrid.y, node.height);

        node.room.width = Mathf.Round(roomWidth / gridCellSize);
        node.room.height = Mathf.Round(roomHeight / gridCellSize);
        node.room.position.x = Mathf.Round(roomX / gridCellSize);
        node.room.position.y = Mathf.Round(roomY / gridCellSize);

        Debug.Log($"Created room width {node.room.width} height {node.room.height} x {node.room.position.x} y {node.room.position.y}");
    }

    private void ModificateGridWithDungeonTree()
    {
        foreach(var leaf in dungeonTree.leafs)
        {
            var room = leaf.room;
            pathfinding.SetWalkableByXY((int)room.position.x, (int)room.position.y, false);
            for(int x = (int)room.position.x; x < (room.position.x + room.width); x++)
            {
                for(int y = (int)room.position.y; y < (room.position.y + room.height); y++)
                {
                    pathfinding.SetWalkableByXY(x, y, false);
                }
            }
        }
    }
}
