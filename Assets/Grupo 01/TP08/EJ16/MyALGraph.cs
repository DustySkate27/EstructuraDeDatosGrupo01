using System.Collections.Generic;
using UnityEngine;

public class MyALGraph<T>
{
    public Dictionary<T, List<(T, int)>> dic;

    public IEnumerable<T> Vertices { get => dic.Keys; }

    public MyALGraph()
    {
        dic = new Dictionary<T, List<(T, int)>>();
    }

    public void AddVertex(T vertex)
    {
        if (!dic.ContainsKey(vertex))
        {
            dic.Add(vertex, new List<(T, int)>());
        }
    }

    public void RemoveVertex(T vertex) 
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

    public List<(T,int)> GetNode(T nodeToGet)
    {
        dic.TryGetValue(nodeToGet, out var nodeRef);
        return nodeRef;
    }

    public void AddEdge(T from, (T, int) edge)
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

    public void RemoveEdge(T from, T to)
    {
        if (dic.TryGetValue(from, out var list)) 
        {
            for(int i = 0;i < list.Count; i++)
            {
                if (list[i].Item1.Equals(to))
                {
                    list.RemoveAt(i);
                }
            }
        }
    }
    public bool ContainsVertex(T vertex)
    {
        if (dic.ContainsKey(vertex)) return true;
        else return false;
    }
    public bool ContainsEdge(T from, T to)
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

    public int? GetWeight(T from, T to)
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
