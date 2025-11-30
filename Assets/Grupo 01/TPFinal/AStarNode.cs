using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AStarNode
{
    public AStarNode parent;
    public Vector2 position;
    public float G;
    public float H;

    public float F { get => G + H; }

    public AStarNode(AStarNode parent, float weight, Vector2 fromPos, Vector2 toPos)
    {
        this.parent = parent;
        G = weight;
        position = fromPos;
        setH(toPos);
    }

    public void setG (float visitCost)
    {
        G = visitCost;
    }

    public void setH(Vector2 target)
    {
        H = Mathf.Abs(position.x - target.x) + Mathf.Abs(position.y - target.y);
    }

    public void SetParent(AStarNode parent) 
    { 
        this.parent = parent;
    }
}

