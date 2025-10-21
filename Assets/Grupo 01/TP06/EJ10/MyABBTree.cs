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

    public virtual TreeNode<T> Insert(T value)
    {
        root = TrackLeaf(root, value);
        return root;
    }

    public TreeNode<T> TrackLeaf(TreeNode<T> pivot, T value) //No admite duplicados
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
    public int GetHeight()
    {

        if (root == null)
        {
            Debug.Log("No encontre");
            return -1;
        }

        int height = 0;
        SearchForFurthestLeaf(root, 0, ref height); //No se cuenta el nodo root

        return height;
    }

    public int GetNodeHeight(TreeNode<T> node)
    {
        if (node == null)
        {
            Debug.Log("No encontre");
            return -1;
        }

        int height = 0;
        SearchForFurthestLeaf(TrackRootReference(root, node), 0, ref height);

        return height;
    }

    public TreeNode<T> TrackRootReference(TreeNode<T> aux, TreeNode<T> pivot)
    {
        if (pivot == null) 
            return null;
        else if (aux == pivot)
            return pivot;
        else if (pivot.value.CompareTo(aux.value) < 0)
            return TrackRootReference(aux.left, pivot);
        else if (pivot.value.CompareTo(aux.value) > 0)
            return TrackRootReference(aux.right, pivot);
        else 
            return null;
    }

    public TreeNode<T> TrackNodeByValue(T value, TreeNode<T> pivot)
    {
        if (pivot.value.CompareTo(value) == 0)
            return pivot;
        else if (pivot.value.CompareTo(value) > 0)
            return TrackNodeByValue(value, pivot.left);
        else if (pivot.value.CompareTo(value) < 0)
            return TrackNodeByValue(value, pivot.right);
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

    public SimpleList<TreeNode<T>> BreadthSearch()
    {
        TreeNode<T> current = root;
        SimpleList<TreeNode<T>> list = new SimpleList<TreeNode<T>>();
        MyQueue<TreeNode<T>> queue = new MyQueue<TreeNode<T>>();
        queue.Enqueue(current);

        while (queue.Count > 0)
        {
            current = queue.Dequeue();
            list.Add(current);
            if (current.left != null)
                queue.Enqueue(current.left);
            if (current.right != null)
                queue.Enqueue(current.right);
        }

        return list;
    }

    public int BalanceFactor()
    {

        int left;
        int right;

        if (root.left != null)
        {
            left = GetNodeHeight(root.left);
        }
        else
        {
            left = -1;
        }
        if (root.right != null)
        {
            right = GetNodeHeight(root.right);
        }
        else
        {
            right = -1;
        }

        int balance = left - right;

        return balance;
    }

    public int NodeBalanceFactor(TreeNode<T> node)
    {
        if (node == null)
            return -1;
        else
        {
            int left;
            int right;

            if (node.left != null)
            {
                left = GetNodeHeight(node.left);
            }
            else
            {
                left = -1;
            }
            if (node.right != null)
            {
                right = GetNodeHeight(node.right);
            }
            else
            {
                right = -1;
            }

            int balance = left - right;

            return balance;
        }
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

