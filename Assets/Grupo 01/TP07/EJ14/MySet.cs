using System.Collections.Generic;
using UnityEngine;

public abstract class MySet<T>
{
    public abstract T[] Elements { get; }
    public override string ToString() => string.Join(", ", Elements);
    public virtual bool IsEmpty() => Elements.Length == 0;
    public virtual void Show() { Debug.Log(ToString()); }

    public abstract void Add(T item);
    public abstract void Remove(T item);
    public abstract void Clear();
    public abstract bool Contains(T item);
    public abstract int Cardinality();
    public abstract MySet<T> Union(MySet<T> other);
    public abstract MySet<T> Intersect(MySet<T> other);
    public abstract MySet<T> Difference(MySet<T> other);
}
