using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLinkedList;
using NUnit.Framework;



public class MyList <T>
 {
    private MyNode<T> root;
    private MyNode<T> tail;
    private List<T> list;
    private bool hasRoot = false;
    private int counter;

    public int Count { get => counter; }

    public T this[int index]
    {
        get 
        { 
          if(root != null)
          {
            MyNode<T> auxNode = root;

            if (index < 0 || index >= counter) throw new IndexOutOfRangeException();

                for (int i = 0; i < index; i++)
                {
                    auxNode = auxNode.NextNode;
                } return auxNode.Value;

          } else { return default; }


        }
        set
        {
            if (root != null)
            {
                MyNode<T> auxNode = root;

                if (index < 0 || index >= counter) throw new IndexOutOfRangeException();

                for (int i = 0; i < index; i++)
                {
                    auxNode = auxNode.NextNode;
                }
                auxNode.Value = value;  

            }
          
        }
    }

    public MyList()
    {
        list = new List<T>();
    }

    public void Add(T value) 
    {
        if(root == null)
        {
            root = new MyNode<T>(value);
            tail = root;
        }
        else
        {
            MyNode<T> nodeToAdd = new MyNode<T>(value);
            nodeToAdd.PrevNode = tail;
            tail = nodeToAdd;
        }
    }

    public void AddRange(T[] values) 
    {
        for(int i = 0;i < values.Length;i++)
        {
            Add(values[i]);
        }
    }

    public void AddRange(MyList<T> values)
    { 
        for (int i = 0;i < values.Count; i++)
        {
            Add(values[i]);
        }
    }

    public void Remove(T value)
    {
        if (root != null)
        {
            MyNode<T> auxNode = root;

            for (int i = 0; i < counter; i++)
            {
                if (auxNode.isEquals(value))
                {
                    auxNode.PrevNode.NextNode = auxNode.NextNode;
                    auxNode.NextNode.PrevNode = auxNode.PrevNode;
                    auxNode = null;
                }
                else { auxNode = auxNode.NextNode;}
            }
        }
    }

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

