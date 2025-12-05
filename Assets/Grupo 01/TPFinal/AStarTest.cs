using CodeMonkey.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AStarTest : MonoBehaviour
{
    private GridSystem grid;
    public int width;
    public int height;
    public float cellSize;

    public bool tileMode;

    public Vector2Int start;
    public Vector2Int finish;

    public GameObject cellBackground;

    Dictionary<Vector2Int, SpriteRenderer> cellSpriteColors;
    
    void Start()
    {
        grid = new GridSystem(width, height, cellSize, new Vector3(transform.position.x, transform.position.y));
        CreateSpriteList();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            tileMode = !tileMode;

        if (Input.GetMouseButtonDown(0))
        {
            if (tileMode) //pone piso
            {
                Vector2Int xy = grid.GetXY(UtilsClass.GetMouseWorldPosition());
                if (GetCellSprite(xy).color == Color.black)
                {
                    if (xy.x >= 0 && xy.y >= 0 && xy.x <= width && xy.y <= height)
                    {
                        grid.SetTile(xy);
                        GetCellSprite(xy).color = Color.white;
                        Debug.Log($"Esta es piso: {grid.GetXY(UtilsClass.GetMouseWorldPosition())}");
                    }
                }
            }


            if (!tileMode) //pone start
            {
                Vector2Int xy = grid.GetXY(UtilsClass.GetMouseWorldPosition());
                SetStart(xy);
            }
        }

        if (Input.GetMouseButtonDown(1)) 
        {
            if (tileMode)//pone pared
            {
                Vector2Int xy = grid.GetXY(UtilsClass.GetMouseWorldPosition());
                if (GetCellSprite(xy).color == Color.white)
                {
                    if (xy.x >= 0 && xy.y >= 0 && xy.x <= width && xy.y <= height)
                    {
                        grid.SetWall(xy);
                        GetCellSprite(xy).color = Color.black;
                        Debug.Log($"Esta es pared: {grid.GetXY(UtilsClass.GetMouseWorldPosition())}");
                    }
                }
            }

            if (!tileMode) //pone finish
            {
                Vector2Int xy = grid.GetXY(UtilsClass.GetMouseWorldPosition());
                SetFinish(xy);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            List<Vector2Int> path = grid.AStarFunction(start, finish);

            if (path != null)
            {
                delayedFor(path);
            }
        }
    }

    public async Task delayedFor(List<Vector2Int> path)
    {
        for (int i = 1; i < path.Count - 1; i++)
        {
            SetVisited(path[i]);
            await Task.Delay(500);
        }
    }

    public void CreateSpriteList()
    {
        cellSpriteColors = new Dictionary<Vector2Int, SpriteRenderer>();
        for (int i = 0; i < grid.GetWidth(); i++)
        {
            for (int j = 0; j < grid.GetHeight(); j++)
            {
                Vector2Int index = new Vector2Int(i, j);
                Vector3 position = grid.GetWorldPosition(i,j) + new Vector3(cellSize / 2, cellSize / 2);
                GameObject current = Instantiate(cellBackground, position, Quaternion.identity);
                cellSpriteColors.Add(index, current.GetComponent<SpriteRenderer>());

                if (index == new Vector2Int(0, 0))
                {
                    start = index;
                    GetCellSprite(start).color = Color.blue;
                }
                if (index == new Vector2Int(grid.GetWidth() - 1, grid.GetHeight() - 1))
                    SetFinish(index);
            }
        }
    }

    public SpriteRenderer GetCellSprite(Vector2Int xy)
    {
        return cellSpriteColors[xy];
    }

    public void SetVisited(Vector2Int xy)
    {
        GetCellSprite(xy).color = Color.green;
    }

    public void SetStart(Vector2Int xy)
    {
        if (xy.x >= 0 && xy.y >= 0 && xy.x <= width && xy.y <= height)
        {
            if (GetCellSprite(xy).color == Color.white)
            {
                if (start != null)
                {
                    Vector2Int previousStart = start;
                    start = xy;
                    GetCellSprite(previousStart).color = Color.white;
                    GetCellSprite(start).color = Color.blue;
                    Debug.Log($"Start: {start}");
                }
            }
        }
    }

    public void SetFinish(Vector2Int xy)
    {
        if (xy.x >= 0 && xy.y >= 0 && xy.x <= width && xy.y <= height)
        {
            if (GetCellSprite(xy).color == Color.white)
            {
                if (finish != null)
                {
                    Vector2Int previousFinish = finish;
                    finish = xy;
                    GetCellSprite(previousFinish).color = Color.white;
                    GetCellSprite(finish).color = Color.red;
                    Debug.Log($"Finish: {finish}");
                }
            }
        }
    }
}
