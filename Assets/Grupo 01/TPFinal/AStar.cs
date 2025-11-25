using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class AStar<T>
{
    public List<List <(T, int)>> visitedNodes;
    public MyQueue<List<(T, int)>> queue;

    public int totalDistance;
    public int tentativeDistance;
    public int currentDistance;

    public void AStarFunc(MyALGraph<T> graph, T from, T to)
    {
        visitedNodes = new List<List<(T, int)>>();
        visitedNodes.Add(graph.GetNode(from));
     //   tentativeDistance = Vector2.Distance(from, to);

        totalDistance = 0;
        currentDistance = 0;
        queue = new MyQueue<List<(T, int)>>();

        foreach (var node in graph.Vertices) 
        {
            if (node.Equals(from))
            {
                return;
            }
            else
            {
                queue.Enqueue(graph.GetNode(node));
            }
        }
    }
}

