using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpaceMonitor : MonoBehaviour
{
    public List<PlanetConfig> planetsList;
    public MyALGraph<string> graph;

    public void Start()
    {
        graph = new MyALGraph<string>();
        foreach (PlanetConfig config in planetsList)
        {
            graph.AddVertex(config.PlanetName);
            foreach (Edge edge in config.edgeList)
            {
                graph.AddEdge(config.PlanetName, (edge.targetPlanet.name, edge.weight));
            }
        }
    }

    public int? GetRoad(string originName, string endName)
    {
        if (graph.ContainsEdge(originName, endName)) //Hay camino directo?
        {
            Debug.Log($"Camino directo: {originName} va a {endName}");
            return graph.GetWeight(originName, endName);
        }
        else if (hasAnyonePlanet(endName, out string newTarget)) //Hay alguien que tenga dicho camino directo?
        {
            Debug.Log($"{newTarget} va a {endName}");
            return GetRoad(newTarget, endName) + GetRoad(originName, newTarget); //Hay forma de llegar desde el origen a dicho alguien?
        }
        return null;
    }

    public bool hasAnyonePlanet (string endName, out string newTarget)
    {
        for(int i = 0; i < planetsList.Count; i++)
        {
            if (graph.ContainsEdge(planetsList[i].PlanetName, endName))
            {
                newTarget = planetsList[i].PlanetName;
                return true;
            }
        }
        newTarget = null;
        return false;
    }

}
