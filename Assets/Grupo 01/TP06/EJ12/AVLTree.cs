using System;
using Unity.VisualScripting;
using UnityEngine;

public class AVLTree<T> : MyABBTree<T> where T : IComparable<T>
{
    public AVLTree() : base() { }

    public AVLTree(T value) : base(value) { }

    public TreeNode<T> InsertN(T value)
    { 
        Root = TrackLeaf(Root, value);
        return Root;
    }

    public override TreeNode<T> TrackLeaf(TreeNode<T> pivot, T value)
    {
        if (pivot == null)
            return new TreeNode<T>(value);

        if (value.CompareTo(pivot.value) < 0)
            pivot.left = TrackLeaf(pivot.left, value);

        else if (value.CompareTo(pivot.value) > 0)
            pivot.right = TrackLeaf(pivot.right, value);

        return Balance(pivot);
    }

    public TreeNode<T> Balance(TreeNode<T> node)
    {
        if (node == null)
            return null;
        else if (NodeBalanceFactor(node) > 1)
        {
            if (NodeBalanceFactor(node.left) >= 0)
                return LLRotation(node);
            else if (NodeBalanceFactor(node.left) <= 0)
                return LRRotation(node);
        }
        else if (NodeBalanceFactor(node) < -1)
        {
            if (NodeBalanceFactor(node.right) <= 0)
                return RRRotation(node);
            else if (NodeBalanceFactor(node.right) >= 0)
                return RLRotation(node);
        }
        
        return node;
    }

    private TreeNode<T> LLRotation(TreeNode<T> node)
    {
        TreeNode<T> x = node.left;
        TreeNode<T> t2 = x.right;

        x.right = node;
        node.left = t2;

        return x;
    }
    private TreeNode<T> RRRotation(TreeNode<T> node) 
    {
        TreeNode<T> x = node.right;
        TreeNode<T> t2 = x.left;

        x.left = node;
        node.right = t2;

        return x;
    }
    private TreeNode<T> RLRotation(TreeNode<T> node)
    {
        node.right = LLRotation(node.right);
        return RRRotation(node);
    }
    private TreeNode<T> LRRotation(TreeNode<T> node) 
    {
        node.left = RRRotation(node.left);
        return LLRotation(node);
    }
}
