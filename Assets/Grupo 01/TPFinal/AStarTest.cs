using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AStarTest : MonoBehaviour
{
    private GridSystem grid;

    void Start()
    {
        grid = new GridSystem(4,2, 20f, new Vector3(-100, -60));

        

        grid.AStarFunction(new Vector2Int(0,0), new Vector2Int(1,0));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 10);
            
        }
        if (Input.GetMouseButtonDown(1)) 
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }

}
