using CodeMonkey.Utils;
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

                Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x +1, y), Color.white, 10f);
                Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x, y +1), Color.white, 10f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 10f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 10f);

        SetValue(2, 1, 4);


    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + origin;
    }
    private Vector2Int GetXY(Vector3 worldPosition)
    {
        return new Vector2Int (Mathf.FloorToInt((worldPosition - origin).x / cellSize), Mathf.FloorToInt((worldPosition - origin).y / cellSize));
    }

    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            textArray[x,y].text = gridArray[x,y].ToString();
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

}
