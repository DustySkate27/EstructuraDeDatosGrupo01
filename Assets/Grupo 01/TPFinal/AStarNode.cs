using System.Numerics;


public class AStarNode<T>
{
    public AStarNode<T> parent;
    public Vector2 position;
    public float tileWeight;
    public float G;

    public AStarNode(AStarNode<T> parent, float weight)
    {
        this.parent = parent;
        tileWeight = weight;
    }

    public float F (float H, float G) 
    { 
        return G + H;
    }


    public float H (Vector2 parentVector)
    {
        return Vector2.Distance(position, parentVector);
    }

    public void SetParent(AStarNode<T> parent) 
    { 
        this.parent = parent;
    }
}

