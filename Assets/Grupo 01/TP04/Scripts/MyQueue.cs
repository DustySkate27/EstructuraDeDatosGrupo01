using JetBrains.Annotations;
using SimpleListLibrary;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;


public class MyQueue<T>
{
     private SimpleList<T> queue;

    public MyQueue(T value)
    {
        queue = new SimpleList<T>();
        queue.Add(value);
    }

    public MyQueue()
    {
        queue = new SimpleList<T>();
    }

    public void Enqueue(T value)
    {
        queue.Add(value);
    }

    public T Dequeue()
    {
        T value = queue[0];
        queue.RemoveAt(0);
        Debug.Log("Dequeued");
        return value;
    }
    public bool TryDequeue(out T value)
    {
        if (queue.Count == 0)
        {
            value = default(T);
            return false;
        }
        else
        {
            value = queue[0];
            queue.RemoveAt(0);
            Debug.Log("Dequeued");
            return true;
        }
    }
    public T Peek()
    {
        return queue[0];
    }
    public bool TryPeek(out T value)
    {
        if (queue.Count == 0)
        {
            value = default(T);
            return false;
        }
        else
        {
            value = queue[0];
            return true;
        }
    }
    public void Clear()
    {
        queue.Clear();
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
    public string ToString()
    {
        //return stack.ToString();

        string result = "";

        for (int i = 0; i < queue.Count; i++)
        {
            result += queue[i].ToString();

            if (i < queue.Count - 1)
            {
                result += ", ";
            }
        }

        return result;
    }

    public int Count { get { return queue.Count; } }
}


