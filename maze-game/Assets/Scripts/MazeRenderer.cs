using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [SerializeField]
    private int _rows;
    [SerializeField]
    private int _cols;

    private float _cellSize = 1f;

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

        foreach(Cell cell in maze)
        {
            if (cell.walls.HasFlag(Walls.TOP))
            {
                Instantiate(wallPrefab, new Vector2(cell.x, cell.y + _cellSize / 2), Quaternion.identity, transform);
            }

            if(cell.walls.HasFlag(Walls.LEFT))
            {
                Instantiate(wallPrefab, new Vector2(cell.x - _cellSize / 2, cell.y), Quaternion.Euler(0, 0, 90f), transform);
            }

            if(cell.x + 1 == _cols)
            {
                if (cell.walls.HasFlag(Walls.RIGHT))
                {
                    Instantiate(wallPrefab, new Vector2(cell.x + _cellSize / 2, cell.y), Quaternion.Euler(0, 0, 90f), transform);
                }
            }

            if(cell.y == 0)
            {
                if (cell.walls.HasFlag(Walls.BOTTOM))
                {
                    Instantiate(wallPrefab, new Vector2(cell.x, cell.y - _cellSize / 2), Quaternion.identity, transform);
                }
            }
        }
    }
}
