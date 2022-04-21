using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator
{
    public static List<Cell> Generate(int rows, int cols)
    {
        List<Cell> maze = new List<Cell>();
        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                maze.Add(new Cell(x, y));
            }
        }

        return maze;
    }

    private static List<Cell> GetUnivisitedNeighbors(List<Cell> maze, Cell cell, int rows, int cols)
    {
        List<Cell> neighbors = new List<Cell>();


        return neighbors;
    }

    private static int ListIndex(int x, int y, int rows)
    {
        return y + x * rows;
    }

}
