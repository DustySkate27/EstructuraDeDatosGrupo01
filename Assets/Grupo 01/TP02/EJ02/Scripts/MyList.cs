using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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

    public int Counter { get => counter; }

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
        for (int i = 0;i < values.Counter; i++)
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

    public void Swap(MyNode<T> node1, MyNode<T> node2)
    {
        MyNode<T> auxNode = node1;

        node1.Value = node2.Value;
        node2.Value = auxNode.Value;
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
    
    public void SelectionSort(Comparison<T> comparison)
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


                if (comparison(auxNode.Value, comparerNode.Value) < 0)
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

    public void BubbleSort(Comparison<T> comparison)
    {
        for (int i = 0; i < counter; i++)
        {
            MyNode<T> auxNode = root;

            for (int j = 0; j < counter - i - 1; j++)
            {
               
                if (comparison(auxNode.Value, auxNode.NextNode.Value) < 0)
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

    public void QuickSort(Comparison<T> comparison, int low, int high)
    {
        if (low < high)
        {
            int pivot = Partition(comparison, low, high);

            QuickSort(comparison, low, pivot-1);
            QuickSort(comparison, pivot + 1, high);

        }
    }

    public int Partition(Comparison<T> comparison, int low, int high)
    {
        MyNode<T> pivot = root;
        MyNode<T> auxNode = root;
    
        for(int k = 0; k < high; k++)
        {
            pivot = pivot.NextNode;
        }

        for(int l = 0; l < low; l++)
        {
            auxNode = auxNode.NextNode;
        }

        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (comparison(auxNode.Value, pivot.Value) < 0)
            {
                i ++;
                MyNode<T> swapNode = root;

                for(int m = 0; m < i; m++)
                {
                    swapNode = swapNode.NextNode;
                }

                Swap(auxNode, swapNode);
               
            }
            auxNode = auxNode.NextNode;
        }

        MyNode<T> finalSwapNode = root;

        for (int m = 0; m < i+1; m++)
        {
            finalSwapNode = finalSwapNode.NextNode;
        }

        Swap(auxNode, finalSwapNode);

        return i+1;
    }
}


