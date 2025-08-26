using JetBrains.Annotations;
using SimpleListLibrary;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Search;
using UnityEngine;

public class MyStack<T>
{
    private SimpleList<T> stack;

    public MyStack(T value)
    {
        stack = new SimpleList<T>();
        stack.Add(value);
    }

    public MyStack()
    {
        stack = new SimpleList<T>();
    }

    public void Push(T value)
    {
        stack.Add(value);
    }

    public T Pop()
    {
        T value = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);
        Debug.Log("Popped");
        return value;
    }
    public bool TryPop(out T value)
    {
        if (stack.Count == 0)
        {
            value = default(T);
            return false;
        }
        else
        {
            value = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            Debug.Log("Popped");
            return true;
        }
    }
    public T Peek()
    {
        return stack[stack.Count - 1];
    }
    public bool TryPeek(out T value)
    {
        if (stack.Count == 0)
        {
            value = default(T);
            return false;
        }
        else
        {
            value = stack[stack.Count - 1];
            return true;
        }
    }
    public void Clear()
    {
        stack.Clear();
    }
    public T[] ToArray(SimpleList<T> stack)
    {
        T[] auxArray = new T[stack.Count];
        for (int i = 0; i < stack.Count; i++)
        {
            auxArray[i] = stack[i];
        }
        return auxArray;
    }
    public override string ToString()
    {
        return stack.ToString();
    }

    public int Count { get { return stack.Count; } }
}
