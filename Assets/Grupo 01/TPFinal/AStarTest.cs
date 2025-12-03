using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AStarTest : MonoBehaviour
{
    private GridSystem grid;
    public int width;
    public int height;
    public float cellSize;

    void Start()
    {
        grid = new GridSystem(width, height, cellSize, new Vector3(transform.position.x, transform.position.y));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 10);
            var path = grid.AStarFunction(new Vector2Int(0, 0), grid.GetXY(UtilsClass.GetMouseWorldPosition()));

            if (path != null)
            {
                for (int i = 0; i < path.Count -1; i++)
                {
                    Debug.DrawLine(grid.GetWorldPosition(path[i].x, path[i].y) + new Vector3(cellSize/2, cellSize/2), grid.GetWorldPosition(path[i+1].x, path[i+1].y) + new Vector3(cellSize / 2, cellSize / 2), Color.green, 10f);
                }
            }
        }
        if (Input.GetMouseButtonDown(1)) 
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }

}
