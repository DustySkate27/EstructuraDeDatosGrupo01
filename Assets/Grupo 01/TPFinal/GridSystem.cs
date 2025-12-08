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

        for (int x = 0; x < gridArray.GetLength(0); x++) 
        {
            for (int y = 0; y < gridArray.GetLength(1); y++) 
            {
                
                Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x +1, y), Color.white, 999999f);
                Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x, y +1), Color.white, 999999f);
                

                Vector2Int currentNode = new Vector2Int(x,y);
                graph.AddVertex(currentNode); //Añade la posicion de la celda al grafo

                foreach(var dir in directions) //y en cada una de sus direcciones
                {
                    Vector2Int neighbor = currentNode + dir; //calcula las celdas limitrofes, sus vecinos

                    if (neighbor.x < 0 || neighbor.x >= width) continue; //Y si se encuentra dentro de la grilla
                    if (neighbor.y < 0 || neighbor.y >= height) continue;
                    graph.AddEdge(currentNode, (neighbor, 1)); //añade al vecino
                }
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 999999f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 999999f);
    }

    public Vector3 GetWorldPosition(int x, int y) //devuelve al posicion real de la coordenada en la pantalla
    {
        return new Vector3(x, y) * cellSize + origin;
    }
    public Vector2Int GetXY(Vector3 worldPosition) //asocia dicha posicion real a la celda mas próxima
    {
        return new Vector2Int (Mathf.FloorToInt((worldPosition - origin).x / cellSize), Mathf.FloorToInt((worldPosition - origin).y / cellSize));
    }

    public List<Vector2Int> AStarFunction(Vector2Int from, Vector2Int to) 
    {
        AStar aStar = new AStar(); //Inicializa un A*
        aStar.AStarFunc(graph, from, to); //Ejecuta el algoritmo
        if(aStar.finalList != null) return aStar.finalList;
        else
            return null;
    }

    public void SetWall(Vector2Int xy)
    {
        if(xy.x >= 0 && xy.y >= 0 && xy.x <= width && xy.y <= height)
        {
            graph.SetIncomingWeight(xy, 999); //Cambia el peso para que A* lo evite
        }

    }

    public void SetTile(Vector2Int xy)
    {
        if (xy.x >= 0 && xy.y >= 0 && xy.x <= width && xy.y <= height)
            graph.SetIncomingWeight(xy, 1); //Cambia el peso para que A* lo recorra
    }

    public int GetWidth()
    {
        return width;
    }
    public int GetHeight()
    {
        return height;
    }
    public float CellSize()
    {
        return cellSize;
    }
}
