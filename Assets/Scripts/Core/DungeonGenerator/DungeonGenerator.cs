using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator 
{
    private Grid<int> grid;
    private BinaryTree dungeonTree;

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
}
