using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private MyALGraph<int> graph;

    void Start()
    {
        graph = new MyALGraph<int>();

        graph.AddVertex(0);
        graph.AddVertex(1);
        graph.AddVertex(2);
        graph.RemoveVertex(0);

        graph.AddEdge(0, (1, 5));
        graph.RemoveEdge(0,1);

        Debug.Log(graph.ContainsVertex(0));
        Debug.Log(graph.ContainsEdge(0,1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
