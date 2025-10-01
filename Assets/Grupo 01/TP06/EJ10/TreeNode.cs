using System;

public class TreeNode<T> where T : IComparable<T>
{
    public T value;
    public TreeNode<T> left, right;

    public TreeNode(T value)
    {
        this.value = value;
        this.left = null;
        this.right = null;
    }
}
