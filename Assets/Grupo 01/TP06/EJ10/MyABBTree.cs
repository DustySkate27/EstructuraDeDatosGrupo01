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
            root = TrackLeaf(root, value);
        else
            TrackLeaf(root, value);
    }

    private TreeNode<T> TrackLeaf(TreeNode<T> pivot, T value) //No admite duplicados
    {
        if (pivot == null)
            return new TreeNode<T>(value);

        if (value.CompareTo(pivot.value) < 0)
            pivot.left = TrackLeaf(pivot.left, value);
        else if (value.CompareTo(pivot.value) > 0)
            pivot.right = TrackLeaf(pivot.right, value);

        return pivot;
    }


    //Buscar el treenode y desde ahi usarlo como referencia al root del arbol o subarbol
    public int PreOrderGetHeight(T value)
    {
        

        TreeNode<T> rootRef = TrackRootReference(root, value); //Devuelve treenode

        if (rootRef == null)
            return -1;

        int height = 0;
        PreOrderSearchForFurthestLeaf(rootRef, 0, ref height); //No se cuenta el nodo root

        return height;
    }

    public int InOrderGetHeight(T value)
    {
        int height = 0;

        TreeNode<T> rootRef = TrackRootReference(root, value); //Devuelve treenode

        InOrderSearchForFurthestLeaf(rootRef, 0, ref height);//No se cuenta el nodo root

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
        Debug.Log(value.CompareTo(pivot.value));
        if (pivot == null) 
            return null;
        else if (value.Equals(pivot.value))
            return pivot;
        else if (value.CompareTo(pivot.value) < 0)
        {
            return TrackRootReference(pivot.left, value);
        }
        else if (value.CompareTo(pivot.value) > 0)
            return TrackRootReference(pivot.right, value);
        else 
            return null;
    }

    private void PreOrderSearchForFurthestLeaf(TreeNode<T> pivot, int currentHeight, ref int maxHeight)
    {
        if (pivot == null)
            return;
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
        //Mathf.Max
    }

    private void InOrderSearchForFurthestLeaf(TreeNode<T> pivot, int currentHeight, ref int maxHeight)
    {
        if (pivot == null)
            Debug.Log("Camino Nulleado");
        else if (pivot.left != null)
        {
            Debug.Log(pivot.left.value.ToString());
            currentHeight++;
            InOrderSearchForFurthestLeaf(pivot.left, currentHeight, ref maxHeight);
        }
        else if (pivot.left == null && pivot.right == null)
        {
            Debug.Log(pivot.value.ToString());
            Debug.Log($"CurrentHeight: {currentHeight}");
            Debug.Log($"MaxHeight: {maxHeight}");
            if (currentHeight > maxHeight)
                maxHeight = currentHeight;
        }
        else
        {
            Debug.Log(pivot.value.ToString());
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
        TreeNode<T> aux = TrackRootReference(root, value);

        var left = PreOrderGetHeight(root.left.value);
        var right = PreOrderGetHeight(root.right.value);

        Debug.Log($"Left: {left}, Right: {right}");

        //int balance = PreOrderGetHeight(root.left.value) - PreOrderGetHeight(root.right.value);

        return 0;
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

