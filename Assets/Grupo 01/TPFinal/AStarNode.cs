using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;


public class AStarNode<T>
{
    public AStarNode<T> parent;
    public Vector2 position;
    public int G;

    public AStarNode(AStarNode<T> parent, int G)
    {
        this.parent = parent;
        this.G = G;
    }

    public float F (float H) 
    { 
        return G + H;
    }

    public void UpdateG(int newG)
    {
        G = newG;
    }
    public void SetParent(AStarNode<T> parent) 
    { 
        this.parent = parent;
    }
}

