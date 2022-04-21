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

        return BFS(maze, rows, cols);
    }

    private static List<Cell> BFS(List<Cell> maze, int rows, int cols)
    {
        var stack = new Stack<Cell>();
        var random = new System.Random(/*seed*/);

        //add first element to stack and mark it as visited
        stack.Push(maze[0]);
        maze[0].Visited = true;

        while(stack.Count > 0)
        {
            Cell current = stack.Pop();

            //check neighbors
            var neighbors = GetUnivisitedNeighbors(maze, current, rows, cols);
            if(neighbors.Count > 0)
            {
                stack.Push(current);
                // get a random neighbor
                int neighborIndex = random.Next(0, neighbors.Count);
                Cell next = neighbors[neighborIndex];

                // mark it as visited
                next.Visited = true;

                // remove walls
                RemoveWalls(current, next);

                // add to stack
                stack.Push(next);
            }
        }
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
                if (!maze[listIndex].Visited)
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
