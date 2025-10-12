using System;
using UnityEngine;

public class AVLTree<T> : MyABBTree<T> where T : IComparable<T>
{
    public AVLTree() : base() { }

    public AVLTree(T value) : base(value) { }

    public void Balance(T value)
    {
        TreeNode<T> node = TrackRootReference(Root, value);
        Debug.Log(node);
        Debug.Log(node.right);
        Debug.Log(node.right.right);
        Debug.Log(node.right.right.right);

        if (BalanceFactor(node.value) > 1 && BalanceFactor(node.left.value) >= 0)
        {
            LLRotation(node);
        }
        else if (BalanceFactor(node.value) < -1 && BalanceFactor(node.right.value) <= 0)
        {
            RRRotation(node);
        }
        else if (BalanceFactor(node.value) < -1 && BalanceFactor(node.right.value) >= 0)
        {
            RLRotation(node);
        }
        else if (BalanceFactor(node.value) > 1 && BalanceFactor(node.left.value) <= 0)
        {
            LRRotation(node);
        }
    }

    private void LLRotation(TreeNode<T> node)
    {
        Debug.Log("LL rotation");
    }
    private void RRRotation(TreeNode<T> node) 
    {
        Debug.Log("RR rotation");
    }
    private void RLRotation(TreeNode<T> node) 
    {
        Debug.Log("RL rotation");
    }
    private void LRRotation(TreeNode<T> node) 
    {
        Debug.Log("LR rotation");
    }
}
