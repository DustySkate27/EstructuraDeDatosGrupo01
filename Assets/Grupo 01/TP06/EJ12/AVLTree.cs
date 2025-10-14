using System;
using UnityEngine;

public class AVLTree<T> : MyABBTree<T> where T : IComparable<T>
{
    public AVLTree() : base() { }

    public AVLTree(T value) : base(value) { }

    public override void Insert(T value)
    {
        Debug.Log("Im in");
        base.Insert(value);
        Balance(Root.value);
    }

    public void Balance(T value)
    {
        TreeNode<T> node = TrackRootReference(Root, value);
        Debug.Log("Im also in");

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
        else
        {
            Debug.Log("Perfect Balance");
        }
    }

    private void LLRotation(TreeNode<T> node)
    {
        Debug.Log("LL rotation");

        TreeNode<T> x = node.left;

        x.right = node;
        node.left = x;

        Debug.Log(x);
        Debug.Log(x.left);
        Debug.Log(x.right);
    }
    private void RRRotation(TreeNode<T> node) 
    {
        Debug.Log("RR rotation");

        TreeNode<T> x = node.right;

        x.left = node;
        node.right = null;

        Debug.Log(x);
        Debug.Log(x.left);
        Debug.Log(x.right);
    }
    private void RLRotation(TreeNode<T> node) 
    {
        Debug.Log("RL rotation");

        TreeNode<T> x = node.right;
        TreeNode<T> y = x.left;

        y.right = x;
        x.left = null;
        node.right = y;
        RRRotation(node);
    }
    private void LRRotation(TreeNode<T> node) 
    {
        Debug.Log("LR rotation");

        TreeNode<T> x = node.left;
        TreeNode<T> y = x.right;

        y.left = x;
        x.right = null;
        node.left = y;
        LLRotation(node);
    }
}
