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
    private GameObject wallPrefab;

    // Start is called before the first frame update
    void Start()
    {
        var maze = MazeGenerator.Generate(_rows, _cols);
        Draw(maze);
    }

    private void Draw(List<Cell> maze)
    {
        
    }
}
