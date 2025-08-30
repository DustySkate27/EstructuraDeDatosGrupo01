using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLinkedList;
using NUnit.Framework;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;



public class MyList <T>
 {
    private MyNode<T> root;
    private MyNode<T> tail;
   // private List<T> list;
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
        //list = new List<T>();
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

            nodeToAdd.PrevNode = tail; //points new node prev to tail
            tail.NextNode = nodeToAdd; //points tails next to new node
            tail = nodeToAdd; //equals tail to new node
        }
        Debug.Log(root == null);
        Debug.Log(root.Value);
        counter++;
    }

    public void AddRange(T[] values) 
    {
        for(int i = 0;i < values.Length;i++)
        {
            Add(values[i]);
        }
    }

    public void AddRange(MyList<T> values) //Podria haberse hecho conectando el ultimo con el nuevo.
    { 
        for (int i = 0;i < values.Count; i++)
        {
            Add(values[i]);
        }
    }

    public bool Remove(T value)
    {
        if (root != null)
        {
            MyNode<T> auxNode = root;

            for (int i = 0; i < counter; i++)
            {
                if (auxNode.isEquals(value))
                {
                    MyNode<T> nextNode = auxNode.NextNode;
                    MyNode<T> prevNode = auxNode.PrevNode;

                    if (counter == 1)
                    {
                        auxNode = null;
                        root = null;
                        tail = null;
                    }
                    else if (auxNode == root)
                    {
                        root = auxNode.NextNode;
                        auxNode = null;
                    }
                    else if (auxNode == tail)
                    {
                        tail = auxNode.PrevNode;
                        auxNode = null;
                    }
                    else
                    {
                        nextNode.PrevNode = prevNode;
                        prevNode.NextNode = nextNode;

                        auxNode = null;
                    }
                        
                    counter--;
                    return true;
                }
                else { auxNode = auxNode.NextNode;}
            }
        }

        return false;
    }

    public void RemoveAt(int index)
    {

        if (root != null)
        {
            MyNode<T> auxNode = root;

            for(int i = 0; i <= index; i++)
            {
                if (i == index)
                {
                    MyNode<T> nextNode = auxNode.NextNode;
                    MyNode<T> prevNode = auxNode.PrevNode;

                    if (counter == 1)
                    {
                        auxNode = null;
                        root = null;
                        tail = null;
                    }
                    else if (auxNode == root)
                    {
                        root = auxNode.NextNode;
                        auxNode = null;
                    }
                    else if (auxNode == tail)
                    {
                        tail = auxNode.PrevNode;
                        auxNode = null;
                    }
                    else
                    {
                        nextNode.PrevNode = prevNode;
                        prevNode.NextNode = nextNode;

                        auxNode = null;
                    }

                    counter--;
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
        else if (index == counter)
        {
            Add(value);
        }
        else if (index > counter || index < 0)
        {
            throw new IndexOutOfRangeException();
        }
        else
        {
            MyNode<T> auxNode = root;

            for (int i = 0;i <= index; i++)
            {
                if (i == index)
                {
                    MyNode<T> next = auxNode.NextNode;
                    MyNode<T> prev = auxNode.PrevNode;
                    MyNode<T> insertingNode = new MyNode<T> (value);

                    next.PrevNode = insertingNode;
                    auxNode.NextNode = insertingNode;
                    insertingNode.NextNode = next;
                    insertingNode.PrevNode = auxNode;
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

        root = null;
        
        counter = 0;
    }

    public override string ToString()
    {
        string text = "";
        MyNode<T> auxNode;

        if (counter == 0)
        {
            text = "Is Empty";
        }
        else
        {
            auxNode = root;

            for (int i = 0; i < counter; i++)
            {
                Debug.Log(text == null);
                Debug.Log(auxNode == null);
                text += auxNode.Value.ToString() + ", ";
                auxNode = auxNode.NextNode;
            }
        }

        return text;
    }
    
    public void SelectionSort()
    {
        MyNode<T> auxNode = root;

        for (int i = 0; i < counter; i++)
        {
            if (i != 0)
            {
                auxNode = root;

                for (int k = 0; k < i; k++) // 'position movement' 
                {
                    auxNode = auxNode.NextNode;
                }
            }

            MyNode<T> comparerNode = auxNode.NextNode;

            for (int j = 0; j < counter - i - 1; j++)
            {
                int auxValue = int.Parse(auxNode.Value.ToString());
                int comparerValue = int.Parse(comparerNode.Value.ToString()); // i + 1

                if (auxValue > comparerValue)
                {
                    MyNode<T> copyNode = null;
                    copyNode.Value = auxNode.Value;
                    auxNode.Value = comparerNode.Value;
                    comparerNode.Value = copyNode.Value;
                }

                comparerNode = comparerNode.NextNode;
            }
        }
    }

    public void BubbleSort()
    {
        for (int i = 0; i < counter; i++)
        {
            MyNode<T> auxNode = root;

            for (int j = 0; j < counter - i - 1; j++)
            {
                int auxValue = int.Parse(auxNode.Value.ToString());
                int nextValue = int.Parse(auxNode.NextNode.Value.ToString());

                if (auxValue > nextValue)
                {
                    MyNode<T> copyNode = null;
                    copyNode.Value = auxNode.NextNode.Value;
                    auxNode.NextNode.Value = auxNode.Value;
                    auxNode.Value = copyNode.Value;
                }
                auxNode = auxNode.NextNode;
            }
        }
    }
}


