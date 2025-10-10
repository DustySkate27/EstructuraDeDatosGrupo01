using SimpleListLibrary;
using System;
using UnityEngine;

public class MyABBTree<T> where T : IComparable<T>
{
    private TreeNode<T> root;

    public TreeNode<T> Root { get => root; set => root = value; }

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

    //Busca el treenode y desde ahi usarlo como referencia al root del arbol o subarbol
    public int GetHeight(T value)
    {
        
        TreeNode<T> rootRef = TrackRootReference(root, value); //Devuelve treenode

        if (rootRef == null)
        {
            Debug.Log("No encontre");
            return -1;
        }

        int height = 0;
        SearchForFurthestLeaf(rootRef, 0, ref height); //No se cuenta el nodo root

        return height;
    }

    public TreeNode<T> TrackRootReference(TreeNode<T> pivot, T value)
    {
        if (pivot == null) 
            return null;
        else if (value.Equals(pivot.value))
            return pivot;
        else if (value.CompareTo(pivot.value) < 0)
            return TrackRootReference(pivot.left, value);
        else if (value.CompareTo(pivot.value) > 0)
            return TrackRootReference(pivot.right, value);
        else 
            return null;
    }

    private void SearchForFurthestLeaf(TreeNode<T> pivot, int currentHeight, ref int maxHeight)
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
            SearchForFurthestLeaf(pivot.left, currentHeight, ref maxHeight);
            SearchForFurthestLeaf(pivot.right, currentHeight, ref maxHeight);
        }
    }

    public SimpleList<TreeNode<T>> PreOrder()
    {
        SimpleList<TreeNode<T>> list = new SimpleList<TreeNode<T>>();
        PreOrder(root, list);
        return list;
    }

    private void PreOrder(TreeNode<T> node, SimpleList<TreeNode<T>> list)
    {
        if (node != null)
        {
            list.Add(node);
            PreOrder(node.left, list);
            PreOrder(node.right, list);
        }
    }

    public SimpleList<TreeNode<T>> InOrder()
    {
        SimpleList<TreeNode<T>> list = new SimpleList<TreeNode<T>>();
        InOrder(root, list);
        return list;
    }

    private void InOrder(TreeNode<T> node, SimpleList<TreeNode<T>> list)
    {
        if (node != null)
        {
            InOrder(node.left, list);
            list.Add(node);
            InOrder(node.right, list);
        }

    }

    public SimpleList<TreeNode<T>> PostOrder()
    {
        SimpleList<TreeNode<T>> list = new SimpleList<TreeNode<T>>();
        PostOrder(root, list);
        return list;
    }

    private void PostOrder(TreeNode<T> node, SimpleList<TreeNode<T>> list)
    {
        if (node != null)
        {
            PostOrder(node.left, list);
            PostOrder(node.right, list);
            list.Add(node);
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
        TreeNode<T> aux = root;
        aux.left = TrackRootReference(root, value).left;
        aux.right = TrackRootReference(root, value).right;

        int left;
        int right;

        if (aux.left != null)
        {
            left = GetHeight(aux.left.value);
        }
        else
        {
            left = -1;
        }
        if (aux.right != null)
        {
            right = GetHeight(aux.right.value);
        }
        else
        {
            right = -1;
        }

        int balance = left - right;

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

