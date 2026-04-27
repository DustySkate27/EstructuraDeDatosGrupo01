using CodeMonkey.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
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

    public GameObject cellBackground;

    private Dictionary<Vector2Int, SpriteRenderer> cellSpriteColors;
    public TextMeshProUGUI modeUI;
    public TextMeshProUGUI possibleUI;
    
    void Start()
    {
        grid = new GridSystem(width, height, cellSize, new Vector3(transform.position.x, transform.position.y)); //Inicializa la grilla
        CreateSpriteList(); //Genera una proyección física de la grilla
        modeUI.text = "Start (Left Click) | Finish (Right Click)";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Alterna entre modo de construccion y modo de origen-meta
        {
            tileMode = !tileMode;
            if (tileMode)
                modeUI.text = "Floor (Left Click) | Wall (Right Click)";
            else
                modeUI.text = "Start (Left Click) | Finish (Right Click)";
        }

        if (Input.GetMouseButtonDown(0)) //Click izq
        {
            if (tileMode) //pone piso
            {
                Vector2Int xy = grid.GetXY(UtilsClass.GetMouseWorldPosition());
                if (xy.x >= 0 && xy.y >= 0 && xy.x < width && xy.y < height) //Si esta en la grilla.
                {
                    if (GetCellSprite(xy).color == Color.black) //y su color es negro, implica que es una pared
                    {
                        grid.SetTile(xy); //Vuelve a la celda de la grilla un tile
                        GetCellSprite(xy).color = Color.white; //Cambia su color a blanco en la proyeccion fisica
                    }
                }
            }

            if (!tileMode) //pone start
            {
                Vector2Int xy = grid.GetXY(UtilsClass.GetMouseWorldPosition());
                SetStart(xy); //Setea el start
            }
        }

        if (Input.GetMouseButtonDown(1)) //Click der
        {
            if (tileMode)//pone pared
            {
                Vector2Int xy = grid.GetXY(UtilsClass.GetMouseWorldPosition());
                if (xy.x >= 0 && xy.y >= 0 && xy.x < width && xy.y < height) //Si esta en la grilla.
                {
                    if (GetCellSprite(xy).color == Color.white) //y su color es blanco, implica que es un piso
                    {
                        grid.SetWall(xy); //Vuelve a la celda de la grilla una pared
                        GetCellSprite(xy).color = Color.black; //Cambia su color a negro en la proyeccion fisica
                    }
                }
            }

            if (!tileMode) //pone finish
            {
                Vector2Int xy = grid.GetXY(UtilsClass.GetMouseWorldPosition());
                SetFinish(xy); //Setea el finish
            }
        }

        if (Input.GetKeyDown(KeyCode.E)) //ejecuta el algoritmo
        {
            if (grid.AStarFunction(start, finish) != null) //Si la funcion devuelve un valor
            {
                List<Vector2Int> path = new List<Vector2Int> (grid.AStarFunction(start, finish)); //inicializa un camino equivalente a FinalList
                possibleUI.text = "YES!!";
                delayedFor(path); //Recorrido con delay
            }
            else
                possibleUI.text = "NO!!";

        }
    }

    public SpriteRenderer GetCellSprite(Vector2Int xy)
    {
        return cellSpriteColors[xy]; //Devuelve el Sprite Renderer de la celda fisica
    }

    public void CreateSpriteList()
    {
        cellSpriteColors = new Dictionary<Vector2Int, SpriteRenderer>(); //Inicializa el diccionario de Sprite Renderers
        for (int i = 0; i < grid.GetWidth(); i++)
        {
            for (int j = 0; j < grid.GetHeight(); j++)
            {
                Vector2Int index = new Vector2Int(i, j);
                Vector3 position = grid.GetWorldPosition(i,j) + new Vector3(cellSize / 2, cellSize / 2);
                GameObject current = Instantiate(cellBackground, position, Quaternion.identity);
                cellSpriteColors.Add(index, current.GetComponent<SpriteRenderer>()); //Añade al diccionario de sprite renderers el del index asociado

                if (index == new Vector2Int(0, 0)) //Si es el origen
                {
                    start = index;
                    GetCellSprite(start).color = Color.blue; //Lo convierte en el start
                }
                if (index == new Vector2Int(grid.GetWidth() - 1, grid.GetHeight() - 1)) //Si es la última celda
                    SetFinish(index); //La convierte en la meta
            }
        }
    }

    public void SetVisited(Vector2Int xy)
    {
        GetCellSprite(xy).color = Color.green; //Cambia el color verde
    }

    public async Task delayedFor(List<Vector2Int> path)
    {
        for (int i = 1; i < path.Count - 1; i++) //Para todo el camino
        {
            SetVisited(path[i]); //Pone en "Visitado" la celda fisica
            await Task.Delay(300); //Delay por segundos
        }
    }

    public void SetStart(Vector2Int xy)
    {
        if (xy.x >= 0 && xy.y >= 0 && xy.x < width && xy.y < height) //Si esta en la grilla
        {
            if (GetCellSprite(xy).color == Color.white) //Y su color es blanco
            {
                if (start != null) //si start existe
                {
                    Vector2Int previousStart = start;
                    start = xy;
                    GetCellSprite(previousStart).color = Color.white; //Pone en blanco el start anterior
                    GetCellSprite(start).color = Color.blue; //Pone en azul el start nuevo
                }
            }
        }
    }
    public void SetFinish(Vector2Int xy)
    {
        if (xy.x >= 0 && xy.y >= 0 && xy.x < width && xy.y < height) //Si esta en la grilla
        {
            if (GetCellSprite(xy).color == Color.white) //Y su color es blanco
            {
                if (finish != null) //si finish existe
                {
                    Vector2Int previousFinish = finish;
                    finish = xy;
                    GetCellSprite(previousFinish).color = Color.white; //Pone en blanco el finish anterior
                    GetCellSprite(finish).color = Color.red; //Pone en azul el finish nuevo
                }
            }
        }
    }

    public void ClearTiles() //Resetea el mapa con las funciones previas
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
                else if (GetCellSprite(index).color == Color.black || GetCellSprite(index).color == Color.green)
                {
                    grid.SetTile(index);
                    GetCellSprite(index).color = Color.white;
                }
                else if (index == new Vector2Int(grid.GetWidth() - 1, grid.GetHeight() - 1))
                    SetFinish(index);
                else
                    GetCellSprite(index).color = Color.white;
            }
        }
        possibleUI.text = "Is it possible?";
    }

}
