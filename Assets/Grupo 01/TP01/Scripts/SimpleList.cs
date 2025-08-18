using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;

namespace Assets.Script
{
    public class SimpleList<T> : ISimpleList<T>
    {
        public T[] arrayD;
        int lastAddedIndex = 0;
        int counter = 0;
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
                return counter;
            }
        }

        public int LastAddedIndex
        {
            get => lastAddedIndex;
        }

        public void Add(T item)
        {
            if (counter >= arrayD.Length) //comprueba si el array dinamico esta lleno
                ExpandArray();

            arrayD[counter] = item;
            counter++;
            lastAddedIndex = counter -1;
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
            int removedIndex = -1;

            #region position

            for (int i = 0; i < arrayD.Length; i++)
            {
                if (arrayD[i].Equals(item))
                {
                    removedIndex = i;
                }
            }

            #endregion

            if (removedIndex != -1)
            {
                T[] auxiliar = new T[arrayD.Length];

                for (int i = 0; i < arrayD.Length; i++)
                {
                    //copying the prevs
                    if (i < removedIndex)
                    {
                        auxiliar[i] = arrayD[i];
                    }

                    //arrays tail
                    if (i == arrayD.Length - 1)
                    {
                        counter--;
                        break;
                    }

                    //copying the posts
                    else if (i >= removedIndex)
                    {
                        auxiliar[i] = arrayD[i + 1];
                    }

                }

                #region copy
                arrayD = new T[counter];

                for (int i = 0; i < arrayD.Length; i++)
                {
                    arrayD[i] = auxiliar[i];
                }
                #endregion

                return true;
            }
            else
                return false;
        }


        #region unused
        public void RemoveLastItem()
        {
            arrayD[lastAddedIndex] = default;
        }
        #endregion

        public void Clear()
        {
            arrayD = new T[4];

            counter = 0;
        }

        public override string ToString()
        {
            string text = "";

            for (int i = 0; i < counter; i++)
                text += arrayD[i].ToString() + ", ";

            return text;

        }

    }
}