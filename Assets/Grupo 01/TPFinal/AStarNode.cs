using UnityEngine;

public class AStarNode
{
    public AStarNode parent;
    public Vector2Int position;
    public float value;
    public float G;
    public float H;

    public float F { get => G + H; }

    public AStarNode(AStarNode parent, float weight, Vector2Int fromPos, Vector2Int toPos)
    {
        this.parent = parent;
        G = weight;
        value = weight;
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

