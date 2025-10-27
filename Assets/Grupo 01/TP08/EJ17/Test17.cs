using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Test17 : MonoBehaviour
{
    [SerializeField] public SpaceMonitor spaceMonitor;
    [SerializeField] public bool isRun;

    void Update()
    {
        if (!isRun)
            return;
        isRun = false;

        spaceMonitor.Start();

        Debug.Log(spaceMonitor.GetRoad("Marte", "Neptuno"));
    }
}
