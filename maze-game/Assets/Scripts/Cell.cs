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
    private int _x;
    private int _y;
    private bool _visited;
    private Walls _walls;

    public Cell (int xPos, int yPos)
    {
        _x = xPos;
        _y = yPos;
        _visited = false;
        _walls = Walls.TOP | Walls.RIGHT | Walls.BOTTOM | Walls.LEFT;
    }

    public int x => _x;
    public int y => _y;
    public bool visited => visited;
    public Walls walls => _walls;
}
