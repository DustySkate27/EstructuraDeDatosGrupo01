using System;
using UnityEngine;

public class TreeNode<T> where T : IComparable<T>
{
    public T value;
    public TreeNode<T> left, right;

    public TreeNode(T value)
    {
        this.value = value;
        left = null;
        right = null;
    }

    public override string ToString()
    {
        return $"Data: {value}";
    }

    public virtual void Execute() //Lo generico en la accion "Procesar el nodo"
    {
        Debug.Log(this);
    }
}
