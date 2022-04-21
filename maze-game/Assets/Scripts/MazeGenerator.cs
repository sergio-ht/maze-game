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
        GetUnivisitedNeighbors(maze, new Cell(99, 99), 100, 100);
        return maze;
    }

    private static List<Cell> GetUnivisitedNeighbors(List<Cell> maze, Cell cell, int rows, int cols)
    {
        List<Cell> neighbors = new List<Cell>();
        var steps = new[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

        foreach(var step in steps)
        {
            int newX = cell.x + step.Item1;
            int newY = cell.y + step.Item2;
            // check bounds
            if(newX >= 0 && newY >= 0 && newX < cols && newY < rows)
            {
                // get index of cell in list (maze)
                int listIndex = ListIndex(newX, newY, rows);

                // add to neighbors if unvisited
                if (!maze[listIndex].visited)
                {
                    neighbors.Add(maze[listIndex]);
                }
            }
        }

        return neighbors;
    }

    private static int ListIndex(int x, int y, int rows)
    {
        return y + x * rows;
    }

}
