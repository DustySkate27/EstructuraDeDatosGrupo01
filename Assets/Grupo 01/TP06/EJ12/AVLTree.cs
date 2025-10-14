using System;
using Unity.VisualScripting;
using UnityEngine;

public class AVLTree<T> : MyABBTree<T> where T : IComparable<T>
{
    public AVLTree() : base() { }

    public AVLTree(T value) : base(value) { }

    public TreeNode<T> InsertN(T value)
    { 
        Root = Balance(TrackLeaf(Root, value));
        return Root;
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
        
            NodeBalanceFactor(node.left);
        NodeBalanceFactor(node.right);
        return node;
    }

    private TreeNode<T> LLRotation(TreeNode<T> node)
    {
        Debug.Log("LL");

        TreeNode<T> x = node.left;
        TreeNode<T> t2 = x.right;

        x.right = node;
        node.left = t2;

        return x;
    }
    private TreeNode<T> RRRotation(TreeNode<T> node) 
    {
        Debug.Log("RR");
        
        TreeNode<T> x = node.right;
        TreeNode<T> t2 = x.left;

        x.left = node;
        node.right = t2;

        return x;
    }
    private TreeNode<T> RLRotation(TreeNode<T> node)
    {
        Debug.Log("RL");

        return LLRotation(RRRotation(node));
    }
    private TreeNode<T> LRRotation(TreeNode<T> node) 
    {
        Debug.Log("LR");
        return RRRotation(LLRotation(node));
    }
}
