using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator
{
    public List<Cell> Generate(int rows, int cols)
    {
        List<Cell> maze = new List<Cell>();
        for(int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                maze.Add(new Cell(x, y));
            }
        }

        return maze;
    }
}
