using SimpleListLibrary;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TP17Executer : MonoBehaviour
{
    public List<PlanetConfig> planetsList;
    public MyALGraph<string> graph;

    private void Start()
    {
        planetsList = GetComponent<List<PlanetConfig>>();
        graph = GetComponent<MyALGraph<string>>();

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

        if (graph.ContainsEdge(originName, endName))
        {
            return graph.GetWeight(originName, endName);
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

    public List<string> GetEdgeList(List<string> namesList, string endName)
    {
        for (int i = 0; i < planetsList.Count; i++)
        {
            if (graph.ContainsEdge(planetsList[i].PlanetName, endName))
            {
                return namesList[i] = planetsList[i].PlanetName;
            }
        }
    }

    /*
    1. buscar en iteracion un contains edge true
    2. if true {buscar conexion a ese}
    3. if false {recursiva}
    4. 
    */

}
