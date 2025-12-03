using CodeMonkey.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class AStarTest : MonoBehaviour
{
    private GridSystem grid;
    public int width;
    public int height;
    public float cellSize;

    public bool tileMode;

    public Vector2Int start;
    public Vector2Int finish;

    void Start()
    {
        grid = new GridSystem(width, height, cellSize, new Vector3(transform.position.x, transform.position.y));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            tileMode = !tileMode;

        if (Input.GetMouseButtonDown(0))
        {
            if (tileMode) //pone piso
            {
                grid.SetTile(grid.GetXY(UtilsClass.GetMouseWorldPosition()));
                Debug.Log($"Esta es piso: {grid.GetXY(UtilsClass.GetMouseWorldPosition())}");
            }

            if (!tileMode) //pone start
            { 
                start = grid.GetXY(UtilsClass.GetMouseWorldPosition());
                Debug.Log($"Start: {start}");
            }
        }

        if (Input.GetMouseButtonDown(1)) 
        {
            if (tileMode)//pone pared
            {
                grid.SetWall(grid.GetXY(UtilsClass.GetMouseWorldPosition()));
                Debug.Log($"Esta es pared: {grid.GetXY(UtilsClass.GetMouseWorldPosition())}");
            }

            if (!tileMode) //pone finish
            {
                finish = grid.GetXY(UtilsClass.GetMouseWorldPosition());
                Debug.Log($"Finish: {finish}");
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            List<Vector2Int> path = grid.AStarFunction(start, finish);

            if (path != null)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Debug.DrawLine(grid.GetWorldPosition(path[i].x, path[i].y) + new Vector3(cellSize / 2, cellSize / 2), grid.GetWorldPosition(path[i + 1].x, path[i + 1].y) + new Vector3(cellSize / 2, cellSize / 2), Color.green, 10f);
                    StartCoroutine(Delay());
                }
            }
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f); 
    }
}
