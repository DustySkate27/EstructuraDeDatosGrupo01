using System.Collections.Generic;
using UnityEngine;


public class Vector2Graph
{
    public Dictionary<Vector2, List<(Vector2, int)>> dic;

    public IEnumerable<Vector2> Vertices { get => dic.Keys; }

    public Vector2Graph()
    {
        dic = new Dictionary<Vector2, List<(Vector2, int)>>();
    }

    public void AddVertex(Vector2 vertex)
    {
        if (!dic.ContainsKey(vertex))
        {
            dic.Add(vertex, new List<(Vector2, int)>());
        }
    }

    public void RemoveVertex(Vector2 vertex)
    {
        if (dic.ContainsKey(vertex))
        {
            dic.Remove(vertex);

            foreach (var entry in dic.Values)
            {
                for (int i = 0; i < entry.Count; i++)
                {
                    if (entry[i].Item1.Equals(vertex))
                    {
                        entry.RemoveAt(i);
                    }
                }
            }
        }
    }

    public List<(Vector2, int)> GetNode(Vector2 nodeToGet)
    {
        dic.TryGetValue(nodeToGet, out var nodeRef);
        return nodeRef;
    }

    public List<(Vector2, int)> GetLisghtestNode(List<(Vector2, int)> nodeRef)
    {
        List<(Vector2, int)> returnedNode = new List<(Vector2, int)>();
        int lowest = nodeRef[0].Item2;

        foreach (var node in nodeRef)
        {
            if (node.Item2 < lowest)
            {
                lowest = node.Item2;
                returnedNode = GetNode(node.Item1);
            }
        }
        return returnedNode;
    }

    public void AddEdge(Vector2 from, (Vector2, int) edge)
    {
        if (dic.TryGetValue(from, out var list))
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Item1.Equals(edge.Item1)) return;
            }
            list.Add(edge);
        }
    }

    public void RemoveEdge(Vector2 from, Vector2 to)
    {
        if (dic.TryGetValue(from, out var list))
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Item1.Equals(to))
                {
                    list.RemoveAt(i);
                }
            }
        }
    }
    public bool ContainsVertex(Vector2 vertex)
    {
        if (dic.ContainsKey(vertex)) return true;
        else return false;
    }
    public bool ContainsEdge(Vector2 from, Vector2 to)
    {
        if (dic.TryGetValue(from, out var list))
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Item1.Equals(to)) return true;
            }
            return false;
        }
        return false;
    }

    public int? GetWeight(Vector2 from, Vector2 to)
    {
        if (dic.TryGetValue(from, out var list))
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Item1.Equals(to)) return list[i].Item2;
            }
            return null;
        }
        return null;
    }
}

