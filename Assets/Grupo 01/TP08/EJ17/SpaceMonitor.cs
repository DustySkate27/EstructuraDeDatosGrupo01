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
        graph = new MyALGraph<string>(); //Creo el grafo
        foreach (PlanetConfig config in planetsSO) //Por cada planeta en mi lista de Scriptable Objects
        {
            graph.AddVertex(config.PlanetName); //Añado cada planeta con su nombre como key
            foreach (Edge edge in config.edgeList) //Por cada arista dentro de la lista de aristas que posee cada planeta
            {
                graph.AddEdge(config.PlanetName, (edge.targetPlanet.name, edge.weight)); //Añado, con su key, cada arista al grafo
            }
        }
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

    public int? VisitingPlanets()
    {
        int? weightVisited = 0; //Inicializo en 0 el peso que voy a mostrar
        for (int i = 0; i < planetsToVisit.Count; i++) //Recorro la lista de planetas
        {
            if(i == planetsToVisit.Count - 1) //Si mi planeta es el último (index)
            {
                return weightVisited; //Returneo el peso, no hay mas aristas.
            }
            else
            {
                //Sino, chequeo si el planeta que estoy procesando puede ir al siguiente planeta en la lista (de i a i+1)
                if (graph.ContainsEdge(planetsToVisit[i].PlanetName, planetsToVisit[i+1].PlanetName)) 
                {
                    weightVisited += graph.GetWeight(planetsToVisit[i].PlanetName, planetsToVisit[i+1].PlanetName); //True, sumo costo de ese viaje
                }
                else
                {
                    planetsToVisit.Clear(); //False, cleareo la lista, el viaje fallo
                    return null;
                }
            }
        }
        planetsToVisit.Clear(); //Si se logra procesar todo el viaje, correctamente, cleareo
        return null;
    }
    public void ClearVisitList()
    {
        planetsToVisit.Clear();
    }




    //LOS CÓDIGOS A CONTINUACIÓN SON FUNCIONALES Y ESTÁN AUTOMATIZADOS, PERO SE DESCONTINUARON POR PETICIÓN DE KEVIN Y FEDE.
    //NO ES NECESARIO QUE LOS LEAN
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
