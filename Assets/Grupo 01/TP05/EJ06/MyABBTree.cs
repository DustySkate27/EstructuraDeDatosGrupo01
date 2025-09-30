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

    private void TrackLeaf(TreeNode<T> pivot, T value)
    {
        if (pivot == null)
            pivot = new TreeNode<T>(value);

        else if (value.CompareTo(pivot.value) < 0)
            TrackLeaf(pivot.left, value);

        else if (value.CompareTo(pivot.value) > 0)
            TrackLeaf(pivot.right, value);
    }

    public int GetHeight()
    {
        int height = 0;

        SearchLeaf(root, 0, ref height);

        return height;
    }

    private void SearchLeaf(TreeNode<T> pivot, int currentHeight, ref int maxHeight)
    {
        if (pivot.left == null && pivot.right == null)
        {
            if (currentHeight > maxHeight)
                maxHeight = currentHeight;
        }
        else
        {
            currentHeight++;
            SearchLeaf(pivot.left, currentHeight, ref maxHeight);
            SearchLeaf(pivot.right, currentHeight, ref maxHeight);
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

