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
        if (root == null)
            root = TrackLeaf(root, value, null);
        else
            TrackLeaf(root, value, null);
    }

    private TreeNode<T> TrackLeaf(TreeNode<T> pivot, T value, TreeNode<T> prevRef) //No admite duplicados
    {
        if (pivot == null)
        {
            pivot = new TreeNode<T>(value);

            if (root == null)
                return pivot;
            else if (prevRef.value.CompareTo(pivot.value) < 0)
                prevRef.right = pivot;
            else if (prevRef.value.CompareTo(pivot.value) > 0)
                prevRef.left = pivot;

            return pivot;
        }

        else if (value.CompareTo(pivot.value) < 0)
        {
            return TrackLeaf(pivot.left, value, pivot);
        }
        else if (value.CompareTo(pivot.value) > 0)
        {
            return TrackLeaf(pivot.right, value, pivot);
        }

        else return null;
    }


    //Buscar el treenode y desde ahi usarlo como referencia al root del arbol o subarbol
    public int PreOrderGetHeight(T value)
    {
        int height = 0;

        TreeNode<T> rootRef = TrackRootReference(root, value); //Devuelve treenode

        PreOrderSearchForFurthestLeaf(rootRef, -1, ref height);

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
            Debug.Log("Camino Nulleado");
        else if (pivot.left == null && pivot.right == null)
        {
            Debug.Log(pivot.value.ToString());

            if (currentHeight > maxHeight)
                maxHeight = currentHeight;
        }
        else
        {
            Debug.Log(pivot.value.ToString());
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

    public void BreadthSearch()
    {
        TreeNode<T> current = root;
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

    public int BalanceFactor(T value)
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

