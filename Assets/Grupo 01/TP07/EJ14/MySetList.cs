using SimpleListLibrary;
using UnityEngine;


public class MySetList<T> : MySet<T>
{
    private MyList<T> set;

    public MySetList(T item)
    {
        set = new MyList<T>();
        set.Add(item);
    }
    public MySetList()
    {
        set = new MyList<T>();
    }

    public override void Add(T item) 
    { 
        if (!set.Contains(item)) set.Add(item);
    }
    public override void Remove(T item) 
    {
        set.Remove(item);
    }
    public override void Clear() 
    {
        set.Clear();
    }
    public override bool Contains(T item) 
    { 
        return set.Contains(item);
    }
    public override void Show() 
    {
        for (int i = 0; i < set.Counter; i++) 
        {
            Debug.Log(set[i]);
        }
    }
    public override string ToString() 
    {
        string stringToShow = "";

        for (int i = 0; i < set.Counter; i++)
        {
            stringToShow += (set[i]) + ", ";
        }

        return stringToShow;
    }
    public override int Cardinality() 
    { 
        return set.Counter;
    }
    public override bool IsEmpty() 
    { 
        return set.IsEmpty();
    }
    public override MySet<T> Union(MySet<T> other)
    {
        MySetList<T> result = new MySetList<T>();

        for (int i = 0; i < set.Counter; i++) result.Add(set[i]);

        for (int i = 0; i < other.Cardinality(); i++)
        {
            if (!set.Contains(other.Elements()[i]))
            {
                result.Add(other.Elements()[i]);
            }
        }

        return result;
    }
    public override MySet<T> Intersect(MySet<T> other)
    { 
        MySetList<T> result = new MySetList<T>();

        for (int i = 0; i < other.Cardinality(); i++)
        {
            if (set.Contains(other.Elements()[i]))
            {
                result.Add(other.Elements()[i]);
            }
        }

        return result;
    }
    public override MySet<T> Difference(MySet<T> other) 
    {
        MySetList<T> result = new MySetList<T>();

        for (int i = 0; i < set.Counter; i++)
        {
            if (!other.Contains(set[i]))
            {
                result.Add(set[i]);
            }
        }

        return result;
    }

    public override T[] Elements()
    {
        T[] arrayToReturn = new T[set.Counter];

        for(int i = 0; i < set.Counter; i++) arrayToReturn[i] = set[i];

        return arrayToReturn;
    }
}