using System;
using UnityEngine;

public class AVLTree<T> : MyABBTree<T> where T : IComparable<T>
{
    public MyABBTree<T> aVLTree;

    public AVLTree()
    {
        aVLTree = new MyABBTree<T>();
    }
    public AVLTree(T value)
    {
        aVLTree = new MyABBTree<T>(value);
    }

    public void Balance(T value)
    {
        TreeNode<T> node = aVLTree.TrackRootReference(aVLTree.Root, value);
        Debug.Log(node);
        Debug.Log(node.left);

        if (aVLTree.BalanceFactor(node.value) > 1 && aVLTree.BalanceFactor(node.left.value) >= 0)
        {
            LLRotation(node);
        }
        else if (aVLTree.BalanceFactor(node.value) < -1 && aVLTree.BalanceFactor(node.right.value) <= 0)
        {
            RRRotation(node);
        }
        else if (aVLTree.BalanceFactor(node.value) < -1 && aVLTree.BalanceFactor(node.right.value) >= 0)
        {
            RLRotation(node);
        }
        else if (aVLTree.BalanceFactor(node.value) > 1 && aVLTree.BalanceFactor(node.left.value) <= 0)
        {
            LRRotation(node);
        }
    }

    private void LLRotation(TreeNode<T> node)
    {
        TreeNode<T> x = node.right;
        TreeNode<T> y = x.right;

        x = node;
        x.right = y;
        x.left = node;

        Debug.Log(x);
        Debug.Log(x.left);
        Debug.Log(x.right);
        
    }
    private void RRRotation(TreeNode<T> node) 
    {

    }
    private void RLRotation(TreeNode<T> node) 
    { 

    }
    private void LRRotation(TreeNode<T> node) 
    { 

    }
}
