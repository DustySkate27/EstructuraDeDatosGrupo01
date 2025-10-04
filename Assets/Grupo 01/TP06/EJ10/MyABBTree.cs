using System;
using UnityEngine;

public class MyABBTree<T> where T : IComparable<T>
{
    private TreeNode<T> root;

    public MyABBTree()
    {
        root = null;
    }

    public MyABBTree(T value)
    {
        root = new TreeNode<T>(value);
    }

    public void Insert(T value)
    {
        TrackLeaf(root, value);
    }

    private void TrackLeaf(TreeNode<T> pivot, T value) //No admite duplicados
    {
        if (pivot == null)
            pivot = new TreeNode<T>(value);
        else if (value.CompareTo(pivot.value) < 0)
            TrackLeaf(pivot.left, value);
        else if (value.CompareTo(pivot.value) > 0)
            TrackLeaf(pivot.right, value);
    }


    //Buscar el treenode y desde ahi usarlo como referencia al root del arbol o subarbol
    public int PreOrderGetHeight(T value)
    {
        int height = 0;
        TreeNode<T> rootRef = TrackRootReference(root, value); //Devuelve treenode
        PreOrderSearchForFurthestLeaf(rootRef, 0, ref height);

        return height;
    }

    public int InOrderGetHeight(T value)
    {
        int height = 0;
        TreeNode<T> rootRef = TrackRootReference(root, value); //Devuelve treenode
        InOrderSearchForFurthestLeaf(rootRef, 0, ref height);

        return height;
    }

    public int PostOrderGetHeight(T value)
    {
        int height = 0;
        TreeNode<T> rootRef = TrackRootReference(root, value); //Devuelve treenode
        PostOrderSearchForFurthestLeaf(rootRef, 0, ref height);

        return height;
    }


    private TreeNode<T> TrackRootReference(TreeNode<T> pivot, T value)
    {
        if (pivot.value.Equals(value))
            return pivot;
        else if (value.CompareTo(pivot.value) < 0)
            return TrackRootReference(pivot.left, value);
        else if (value.CompareTo(pivot.value) > 0)
            return TrackRootReference(pivot.right, value);
        else return null;
    }

    private void PreOrderSearchForFurthestLeaf(TreeNode<T> pivot, int currentHeight, ref int maxHeight)
    {
        if (pivot == null)
            throw new ArgumentNullException("bye bye");
        else if (pivot.left == null && pivot.right == null)
        {
            if (currentHeight > maxHeight)
                maxHeight = currentHeight;
        }
        else
        {
            currentHeight++;
            PreOrderSearchForFurthestLeaf(pivot.left, currentHeight, ref maxHeight);
            PreOrderSearchForFurthestLeaf(pivot.right, currentHeight, ref maxHeight);
        }
    }

    private void InOrderSearchForFurthestLeaf(TreeNode<T> pivot, int currentHeight, ref int maxHeight)
    {
        if (pivot == null)
            throw new ArgumentNullException("bye bye");
        else if (pivot.left != null)
        {
            currentHeight++;
            InOrderSearchForFurthestLeaf(pivot.left, currentHeight, ref maxHeight);
        }
        else if (pivot.left == null && pivot.right == null)
        {
            if (currentHeight > maxHeight)
                maxHeight = currentHeight;
        }
        else
        {
            currentHeight++;
            InOrderSearchForFurthestLeaf(pivot.right, currentHeight, ref maxHeight);
        }
    }

    private void PostOrderSearchForFurthestLeaf(TreeNode<T> pivot, int currentHeight, ref int maxHeight)
    {
        if (pivot == null)
            throw new ArgumentNullException();
        else if (pivot.left != null)
        {
            currentHeight++;
            PostOrderSearchForFurthestLeaf(pivot.left, currentHeight, ref maxHeight);
        }
        else if (pivot.right != null)
        {
            currentHeight++;
            PostOrderSearchForFurthestLeaf(pivot.right, currentHeight, ref maxHeight);
        }
        else if (pivot.left == null && pivot.right == null)
        {
            if (currentHeight > maxHeight)
                maxHeight = currentHeight;
        }

    }

    private void BreadthSearch(TreeNode<T> current)
    {
        MyQueue<TreeNode<T>> queue = new MyQueue<TreeNode<T>>();
        queue.Enqueue(current);

        while (queue.Count > 0)
        {
            current = queue.Dequeue();
            Debug.Log(current.value.ToString());
            if (current.left != null)
                queue.Enqueue(current.left);
            if (current.right != null)
                queue.Enqueue(current.right);
        }
    }

    private int BalanceFactor(T value)
    {
        int balance = 0;
        TreeNode<T> aux = TrackRootReference(root, value);

        balance = PreOrderGetHeight(aux.left.value) - PreOrderGetHeight(aux.right.value);

        return balance;
    }





}


/*
       _-_
    /~~   ~~\
 /~~         ~~\
{               }
 \  _-     -_  /
   ~  \\ //  ~
_- -   | | _- _
  _ -  | |   -_
      // \\
*/

