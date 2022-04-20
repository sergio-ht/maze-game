using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Flags]
public enum Walls
{
    TOP = 1,
    RIGHT = 2,
    BOTTOM = 4,
    LEFT = 8,
}

public class Cell
{
    private int x;
    private int y;
    private bool visited;
    private Walls walls;

    public Cell (int x, int y)
    {
        this.x = x;
        this.y = y;
        this.visited = false;
        this.walls = Walls.TOP | Walls.RIGHT | Walls.BOTTOM | Walls.LEFT;
    }
}
