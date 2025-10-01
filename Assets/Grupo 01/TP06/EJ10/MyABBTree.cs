using System;

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
    public int GetHeight(T value)
    {
        int height = 0;
        TreeNode<T> rootRef = TrackRootReference(root, value); //Devuelve treenode
        SearchForFurthestLeaf(rootRef, 0, ref height);

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

    private void SearchForFurthestLeaf(TreeNode<T> pivot, int currentHeight, ref int maxHeight)
    {
        if (pivot.left == null && pivot.right == null)
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

