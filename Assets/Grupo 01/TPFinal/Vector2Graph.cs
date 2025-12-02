using System.Collections.Generic;
using UnityEngine;


public class Vector2Graph
{
    public Dictionary<Vector2Int, List<(Vector2Int, int)>> dic;

    public IEnumerable<Vector2Int> Vertices { get => dic.Keys; }

    public Vector2Graph()
    {
        dic = new Dictionary<Vector2Int, List<(Vector2Int, int)>>();
    }

    public void AddVertex(Vector2Int vertex)
    {
        if (!dic.ContainsKey(vertex))
        {
            dic.Add(vertex, new List<(Vector2Int, int)>());
        }
    }

    public void RemoveVertex(Vector2Int vertex)
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

    public List<(Vector2Int, int)> GetNode(Vector2Int nodeToGet)
    {
        dic.TryGetValue(nodeToGet, out var nodeRef);
        return nodeRef;
    }

    public void AddEdge(Vector2Int from, (Vector2Int, int) edge)
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

    public void RemoveEdge(Vector2Int from, Vector2Int to)
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
    public bool ContainsVertex(Vector2Int vertex)
    {
        if (dic.ContainsKey(vertex)) return true;
        else return false;
    }
    public bool ContainsEdge(Vector2Int from, Vector2Int to)
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

    public int? GetWeight(Vector2Int from, Vector2Int to)
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

