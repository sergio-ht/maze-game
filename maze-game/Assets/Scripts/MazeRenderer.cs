using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        var maze = MazeGenerator.Generate(_rows, _cols);
        Draw(maze);
    }

    private void Draw(List<Cell> maze)
    {
        int i = 0;
        foreach (Cell cell in maze)
        {
            Vector2 position = new Vector2(cell.x, cell.y) * _cellSize;
            if (cell.walls.HasFlag(Walls.TOP))
            {
                var wall = Instantiate(wallPrefab, position + new Vector2(0, _cellSize / 2), Quaternion.identity, transform);
                wall.transform.localScale = wall.transform.localScale * _cellSize;
            }

            if (cell.walls.HasFlag(Walls.LEFT))
            {
                var wall = Instantiate(wallPrefab, position + new Vector2(-_cellSize / 2, 0), Quaternion.Euler(0, 0, 90f), transform);
                wall.transform.localScale = wall.transform.localScale * _cellSize;
            }

            if (cell.x + 1 == _cols)
            {
                if (cell.walls.HasFlag(Walls.RIGHT))
                {
                    var wall = Instantiate(wallPrefab, position + new Vector2(_cellSize / 2, 0), Quaternion.Euler(0, 0, 90f), transform);
                    wall.transform.localScale = wall.transform.localScale * _cellSize;
                }
            }

            if (cell.y == 0)
            {
                if (cell.walls.HasFlag(Walls.BOTTOM))
                {
                    var wall = Instantiate(wallPrefab, position + new Vector2(0, -_cellSize / 2), Quaternion.identity, transform);
                    wall.transform.localScale = wall.transform.localScale * _cellSize;
                }
            }
        }
    }
}
