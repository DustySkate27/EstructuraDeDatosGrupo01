using SimpleListLibrary;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpaceMonitor : MonoBehaviour
{
    public List<PlanetConfig> planetsSO;
    private SimpleList<PlanetConfig> planetsToVisit = new SimpleList<PlanetConfig>();
    public MyALGraph<string> graph;

    public void Start()
    {
        graph = new MyALGraph<string>();
        foreach (PlanetConfig config in planetsSO)
        {
            graph.AddVertex(config.PlanetName);
            foreach (Edge edge in config.edgeList)
            {
                graph.AddEdge(config.PlanetName, (edge.targetPlanet.name, edge.weight));
            }
        }
    }

    public int? VisitingPlanets()
    {
        int? weightVisited = 0;
        for (int i = 0; i < planetsToVisit.Count; i++)
        {
            if(i == planetsToVisit.Count - 1)
            {
                Debug.Log("final");
                return weightVisited;
            }
            else
            {
                if (graph.ContainsEdge(planetsToVisit[i].PlanetName, planetsToVisit[i+1].PlanetName))
                {
                    weightVisited += graph.GetWeight(planetsToVisit[i].PlanetName, planetsToVisit[i+1].PlanetName);
                }
                else
                {
                    Debug.Log("no hay nada");
                    planetsToVisit.Clear();
                    return null;
                }
            }
        }
        planetsToVisit.Clear();
        return null;
    }

    public void AddPlanetToVisit(PlanetConfig planetToAdd)
    {
        if (planetsToVisit.Count == 0)
        {
            Debug.Log(planetToAdd.PlanetName);
            planetsToVisit = new SimpleList<PlanetConfig>();
            planetsToVisit.Add(planetToAdd);
        }
        else if (planetsToVisit.Count > 0)
        {
            Debug.Log(planetToAdd.PlanetName);
            planetsToVisit.Add(planetToAdd);
        }
    }

    public void ClearVisitList()
    {
        planetsToVisit.Clear();
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
        for(int i = 0; i < planetsSO.Count; i++)
        {
            if (graph.ContainsEdge(planetsSO[i].PlanetName, endName))
            {
                newTarget = planetsSO[i].PlanetName;
                return true;
            }
        }
        newTarget = null;
        return false;
    }

}
