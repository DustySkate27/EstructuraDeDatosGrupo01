using System.Collections.Generic;
using UnityEngine;

public class SpaceMonitor : MonoBehaviour
{
    public List<PlanetConfig> planetsList;
    public MyALGraph<string> graph;

    private void Start()
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
        PlanetConfig origin = TrackPlanet(originName);
        PlanetConfig end = TrackPlanet(endName);

        if (graph.ContainsEdge(originName, endName)) //Hay camino directo?
        {
            return graph.GetWeight(originName, endName);
        }
        else if (hasAnyonePlanet(endName, out string newTarget)) //Hay alguien que tenga dicho camino directo?
        {
            return GetRoad(originName, newTarget) + GetRoad(newTarget, endName); //Hay forma de llegar desde el origen a dicho alguien?
        }
        return -1;
    }
    public PlanetConfig TrackPlanet(string planetName)
    {
        for (int i = 0; i < planetsList.Count; i++)
        {
            if (planetsList[i].PlanetName == planetName) return planetsList[i];
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
