using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLinkedList;
using NUnit.Framework;
using Unity.VisualScripting;



public class MyList <T>
 {
    private MyNode<T> root;
    private MyNode<T> tail;
    private List<T> list;
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
            counter = 1;
        }
        else
        {
            MyNode<T> nodeToAdd = new MyNode<T>(value);

            nodeToAdd.PrevNode = tail; //points new node prev to tail
            tail.NextNode = nodeToAdd; //points tails next to new node
            tail = nodeToAdd; //equals tail to new node
            counter++;
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
                    counter--;
                    return;
                }
                else { auxNode = auxNode.NextNode;}
            }
        }
    }

    public void RemoveAt(int index)
    {
        if (root != null)
        {
            MyNode<T> auxNode = root;

            for(int i = 0; i <= index; i++)
            {
                if(i == index)
                {
                    auxNode.PrevNode.NextNode = auxNode.NextNode;
                    auxNode.NextNode.PrevNode = auxNode.PrevNode;
                    auxNode = null;
                    counter--;
                    return;
                }
                else { auxNode = auxNode.NextNode; }
            }
        }
    }

    public void Insert(int index, T value)
    {
        if(root == null)
        {
            root = new MyNode<T>(value);
            tail = root;
            counter = 1;
        }
        else
        {
            MyNode<T> auxNode = root;

            for (int i = 0;i <= index; i++)
            {
                if (i == index)
                {
                    MyNode<T> nextNode = auxNode.NextNode;
                    MyNode<T> prevNode = auxNode.PrevNode;
                    MyNode<T> insertingNode = new MyNode<T> (value);

                    insertingNode.NextNode = nextNode;
                    insertingNode.PrevNode = prevNode;
                    nextNode.PrevNode = insertingNode;
                    prevNode.NextNode = insertingNode;
                    counter++;
                    return;
                }
                else { auxNode = auxNode.NextNode; }
            }
        }
    }

    public bool IsEmpty()
    {
        if (root != null)
        {
            return true;
        }
        else return false;
    }

    public void Clear()
    {
        MyNode<T> inClearNode = root;
        MyNode<T> nextNodeToClear = null;

        for(int i = 0; i < counter; i++)
        {
            nextNodeToClear = inClearNode.NextNode;
            inClearNode.NextNode = null;
            inClearNode.PrevNode = null;
            inClearNode = null;

            inClearNode = nextNodeToClear;
        }

        counter = 0;
    }

    public override string ToString()
    {
        string text = "";
        MyNode<T> auxNode = root;

        for (int i = 0; i < counter; i++)
            text += auxNode.Value.ToString() + ", ";

        return text;

    }



}

