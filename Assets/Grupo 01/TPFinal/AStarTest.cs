using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class AStarTest : MonoBehaviour
{
    private GridSystem grid;

    void Start()
    {
        grid = new GridSystem(4,2, 20f, new Vector3(-100, -60));
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
