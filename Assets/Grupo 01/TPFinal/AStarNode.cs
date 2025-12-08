using UnityEngine;

public class AStarNode
{
    public AStarNode parent; //Nodo por el cual se accede al actual
    public Vector2Int position; //Posicion vectorial
    public float weight;
    public float G; //Costo de acceso al nodo
    public float H; //Heuristica hacia la meta

    public float F { get => G + H; } //Calculo de costo + estimado de heuristica restante

    public AStarNode(AStarNode parent, float weight, Vector2Int fromPos, Vector2Int toPos)
    {
        this.parent = parent;
        G = weight;
        this.weight = weight;
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

