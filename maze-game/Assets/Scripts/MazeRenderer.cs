using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [SerializeField]
    private int _rows;
    [SerializeField]
    private int _cols;
    [SerializeField]
    private float _cellSize = 5f;

    [SerializeField]
    private GameObject wallPrefab;
    [SerializeField]
    private GameObject floorPrefab;

    [SerializeField]
    private GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        var maze = MazeGenerator.Generate(_rows, _cols);
        Draw(maze);
        drawGoal(maze);
    }

    private void Draw(List<Cell> maze)
    {
        foreach (Cell cell in maze)
        {
            var floor = Instantiate(floorPrefab, new Vector2(cell.x, cell.y) * _cellSize, Quaternion.identity, transform);

            Vector2 position = new Vector2(cell.x, cell.y) * _cellSize;
            if (cell.Walls.HasFlag(Walls.TOP))
            {
                var wall = Instantiate(wallPrefab, position + new Vector2(0, _cellSize / 2), Quaternion.identity, transform);
                wall.transform.localScale = wall.transform.localScale * _cellSize;
            }

            if (cell.Walls.HasFlag(Walls.LEFT))
            {
                var wall = Instantiate(wallPrefab, position + new Vector2(-_cellSize / 2, 0), Quaternion.Euler(0, 0, 90f), transform);
                wall.transform.localScale = wall.transform.localScale * _cellSize;
            }

            if (cell.x + 1 == _cols)
            {
                if (cell.Walls.HasFlag(Walls.RIGHT))
                {
                    var wall = Instantiate(wallPrefab, position + new Vector2(_cellSize / 2, 0), Quaternion.Euler(0, 0, 90f), transform);
                    wall.transform.localScale = wall.transform.localScale * _cellSize;
                }
            }

            if (cell.y == 0)
            {
                if (cell.Walls.HasFlag(Walls.BOTTOM))
                {
                    var wall = Instantiate(wallPrefab, position + new Vector2(0, -_cellSize / 2), Quaternion.identity, transform);
                    wall.transform.localScale = wall.transform.localScale * _cellSize;
                }
            }
        }
    }

    private void drawGoal(List<Cell> maze)
    {
        Cell lastCell = maze.Last();
        goal.transform.position = new Vector2(lastCell.x, lastCell.y) * _cellSize;
    }
}
