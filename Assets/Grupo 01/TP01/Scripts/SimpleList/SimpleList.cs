using Unity.VisualScripting;
using UnityEngine.Assertions.Must;

namespace Assets.Script
{
    public class SimpleList<T> : ISimpleList<T>
    {
        public T[] arrayD;
        int lastAddedIndex = 0;
        int arrayBaseLenght = 4;

        public SimpleList()
        {
            arrayD = new T[arrayBaseLenght];
        }

        public T this[int index]
        {
            get { return arrayD[index]; }
            set
            {
                if (index < arrayD.Length)
                arrayD[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return lastAddedIndex;
            }
        }

        public void Add(T item)
        {

            if (lastAddedIndex >= arrayD.Length) //comprueba si el array dinamico esta lleno
                ExpandArray();

            arrayD[lastAddedIndex] = item;
            lastAddedIndex++;
        }

        public void AddRange(T[] collection)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                Add(collection[i]);
            }
        }

        public void ExpandArray()
        {
            T[] arrayAux = new T[arrayD.Length];

            for (int j = 0; j < arrayD.Length; j++) //copia de OG a AUX
            {
                arrayAux[j] = arrayD[j];
            }

            arrayD = new T[arrayAux.Length * 2]; //nuevo array, duplica su capacidad

            for (int j = 0; j < arrayAux.Length; j++) //copia de AUX a OG
            {
                arrayD[j] = arrayAux[j];
            }
        }


        public bool Remove(T item)
        {
            for (int i = 0; i < arrayD.Length; i++)
            {
                if (arrayD[i].Equals(item))
                {
                    arrayD[i] = default;
                    //lastAddedIndex--;
                    return true;
                }
            }
            return false;
        }

        public void RemoveLastItem()
        {
            if (arrayD[lastAddedIndex] != null)
            {
                arrayD[lastAddedIndex] = default;
                lastAddedIndex--;
                return;
            }
        }

        public void Clear()
        {
            arrayD = new T[4];

            lastAddedIndex = 0;
        }

        public override string ToString()
        {
            string text = "";

            if (arrayD == null)
                text = "null";

            else
                for (int i = 0; i < lastAddedIndex; i++)
                    text += arrayD[i].ToString() + ", ";

            return text;
        }

    }
}