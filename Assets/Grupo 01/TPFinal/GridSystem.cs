using CodeMonkey.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class GridSystem 
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 origin;
    private int[,] gridArray;
    private TextMesh[,] textArray;

    private Vector2Int[] directions = { 
        new Vector2Int(1, 0),
        new Vector2Int(-1, 0),
        new Vector2Int(0, 1),
        new Vector2Int(0, -1),
    };

    public Vector2Graph graph = new Vector2Graph();

    public GridSystem(int width, int height, float cellSize, Vector3 origin)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.origin = origin;

        gridArray = new int[width, height];
        textArray = new TextMesh[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++) 
        {
            for (int y = 0; y < gridArray.GetLength(1); y++) 
            {
                textArray[x,y] = UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x,y) + new Vector3(cellSize, cellSize) * .5f, 30, Color.white, TextAnchor.MiddleLeft);

                Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x +1, y), Color.white, 999999f);
                Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x, y +1), Color.white, 999999f);
                

                Vector2Int currentNode = new Vector2Int(x,y);
                graph.AddVertex(currentNode);

                foreach( var dir in directions)
                {
                    Vector2Int neighbor = currentNode + dir;

                    if (neighbor.x < 0 || neighbor.x >= width) continue;
                    if (neighbor.y < 0 || neighbor.y >= height) continue;
                    graph.AddEdge(currentNode, (neighbor, 1));
                }
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 999999f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 999999f);

        SetValue(2, 1, 4);
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + origin;
    }
    public Vector2Int GetXY(Vector3 worldPosition)
    {
        return new Vector2Int (Mathf.FloorToInt((worldPosition - origin).x / cellSize), Mathf.FloorToInt((worldPosition - origin).y / cellSize));
    }

    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            textArray[x,y].text = gridArray[x,y].ToString();
            graph.dic.ContainsKey(new Vector2Int(x,y));
        }
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        SetValue(GetXY(worldPosition).x, GetXY(worldPosition).y, value);
    }

    public int GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else return 0;
    }

    public int GetValue(Vector3 worldPosition)
    {
        return GetValue(GetXY(worldPosition).x, GetXY(worldPosition).y);
    }

    public List<Vector2Int> AStarFunction(Vector2Int from, Vector2Int to)
    {
        AStar aStar = new AStar();
        aStar.AStarFunc(graph, from, to);
        Debug.Log(aStar.finalList);
        if(aStar.finalList != null) return aStar.finalList;
        else
            return null;
    }

    public void SetWall(Vector2Int xy)
    {
        graph.SetIncomingWeight(xy, 999);
        textArray[xy.x, xy.y] = UtilsClass.CreateWorldText(999.ToString(), null, GetWorldPosition(xy.x, xy.y) + new Vector3(cellSize, cellSize) * .5f, 30, Color.white, TextAnchor.MiddleLeft);

    }

    public void SetTile(Vector2Int xy)
    {
        graph.SetIncomingWeight(xy, 1);
    }


}
