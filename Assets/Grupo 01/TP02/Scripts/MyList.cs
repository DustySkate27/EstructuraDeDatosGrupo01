using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLinkedList;
using NUnit.Framework;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;


public class MyList <T>
 {
    private MyNode<T> root;
    private MyNode<T> tail;
    private List<T> list;
    private bool hasRoot = false;

    public int Count { get; private set; }
    public T this[int index]
    {
        get { return list[index]; }
        set
        {
            if (index < list.Count)
                list[index] = value;
        }
    }


    public MyList(T rootValue)
    {
        list = new List<T>();
        root = new MyNode<T>(rootValue, -1, 1, 0);
    }

    public void Add(T value) { }

    public void AddRange(T[] values) { }

    public void AddRange(MyList<T> values) { }

    public void Remove(T value) { }

    public void RemoveAt(int index) { }

    public void Insert(int index, T value) { }

    //public bool IsEmpty() {  }

    public void Clear() { }

    //public override string ToString()
    //{
    //    string text = "";

    //    for (int i = 0; i < counter; i++)
    //        text += arrayD[i].ToString() + ", ";

    //    return text;

    //}



}

