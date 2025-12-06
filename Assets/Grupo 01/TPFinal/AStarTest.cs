using CodeMonkey.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using TMPro;
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

    private Dictionary<Vector2Int, SpriteRenderer> cellSpriteColors;
    public TextMeshProUGUI modeUI;
    public TextMeshProUGUI possibleUI;
    
    void Start()
    {
        grid = new GridSystem(width, height, cellSize, new Vector3(transform.position.x, transform.position.y));
        CreateSpriteList();
        modeUI.text = "Start (Left Click) | Finish (Right Click)";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tileMode = !tileMode;
            if (tileMode)
                modeUI.text = "Floor (Left Click) | Wall (Right Click)";
            else
                modeUI.text = "Start (Left Click) | Finish (Right Click)";
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (tileMode) //pone piso
            {
                Vector2Int xy = grid.GetXY(UtilsClass.GetMouseWorldPosition());
                if (xy.x >= 0 && xy.y >= 0 && xy.x < width && xy.y < height)
                {
                    if (GetCellSprite(xy).color == Color.black)
                    {
                        grid.SetTile(xy);
                        GetCellSprite(xy).color = Color.white;
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
                if (xy.x >= 0 && xy.y >= 0 && xy.x < width && xy.y < height)
                {
                    if (GetCellSprite(xy).color == Color.white)
                    {
                        grid.SetWall(xy);
                        GetCellSprite(xy).color = Color.black;
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
            if (grid.AStarFunction(start, finish) != null)
            {
                List<Vector2Int> path = new List<Vector2Int> (grid.AStarFunction(start, finish));
                possibleUI.text = "YES!!";
                delayedFor(path);
            }
            else
                possibleUI.text = "NO!!";

        }
    }

    public async Task delayedFor(List<Vector2Int> path)
    {
        for (int i = 1; i < path.Count - 1; i++)
        {
            SetVisited(path[i]);
            await Task.Delay(300);
        }
    }

    public void ClearTiles()
    {
        for (int i = 0; i < grid.GetWidth(); i++)
        {
            for (int j = 0; j < grid.GetHeight(); j++)
            {
                Vector2Int index = new Vector2Int(i, j);

                if (index == new Vector2Int(0, 0))
                {
                    SetStart(index);
                }
                else if (index == new Vector2Int(grid.GetWidth() - 1, grid.GetHeight() - 1))
                    SetFinish(index);
                else if (GetCellSprite(index).color == Color.black)
                {
                    grid.SetTile(index);
                    GetCellSprite(index).color = Color.white;
                }
                else
                    GetCellSprite(index).color = Color.white;
            }
        }
        possibleUI.text = "Is it possible?";
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
        if (xy.x >= 0 && xy.y >= 0 && xy.x < width && xy.y < height)
        {
            if (GetCellSprite(xy).color == Color.white)
            {
                if (start != null)
                {
                    Vector2Int previousStart = start;
                    start = xy;
                    GetCellSprite(previousStart).color = Color.white;
                    GetCellSprite(start).color = Color.blue;
                }
            }
        }
    }

    public void SetFinish(Vector2Int xy)
    {
        if (xy.x >= 0 && xy.y >= 0 && xy.x < width && xy.y < height)
        {
            if (GetCellSprite(xy).color == Color.white)
            {
                if (finish != null)
                {
                    Vector2Int previousFinish = finish;
                    finish = xy;
                    GetCellSprite(previousFinish).color = Color.white;
                    GetCellSprite(finish).color = Color.red;
                }
            }
        }
    }
}
