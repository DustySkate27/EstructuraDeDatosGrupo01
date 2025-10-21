using System;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;

namespace SimpleListLibrary
{
    public class SimpleList<T> : ISimpleList<T>
    {
        public T[] arrayD;
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


        public void Add(T item)
        {
            if (counter >= arrayD.Length) //comprueba si el array dinamico esta lleno
                ExpandArray();

            if (arrayD.Length <= 0)
            {
                arrayD = new T[arrayBaseLenght];
            }

            arrayD[counter] = item;
            counter++;
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

            for (int i = 0; i < arrayD.Length; i++) //se busca registrar el index para poder usarlo como pivot y obviar su valor en la copia.
            {
                if (arrayD[i].Equals(item))
                {
                    removedIndex = i;
                }
            }

            #endregion

            if (removedIndex != -1) //si el index no cambia, no existe tal item
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

        public bool RemoveAt(int index)
        {
            int removedIndex = index;

            if (removedIndex != -10)
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
        public void Clear()
        {
            arrayD = new T[4];
            counter = 0;
        }

        public bool Contains(T value)
        {
            for (int i = 0; i < counter; i++)
            {
                if (arrayD[i].Equals(value)) return true;
            }
            return false;
        }

        public bool IsEmpty()
        {
            return counter == 0?  true :  false;
        }

        public void SelectionSort(Comparison<T> comparison)
        {
            for (int i = 0; i < counter - 1; i++) //El i no puede apuntar al tail, porque queda siempre a la derecha (valor más grande)
            {
                int minIndex = i;
                for (int j = i + 1; j < counter; j++) //j empieza una posicion despues del puntero a comparar
                {
                    if (comparison(arrayD[j], arrayD[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i) //Si al final del for(j) el minIndex cambia, se le cambia su valor.
                {
                    T aux = arrayD[i];
                    arrayD[i] = arrayD[minIndex];
                    arrayD[minIndex] = aux;
                }
            }
        }

        public void BubbleSort(Comparison<T> comparison)
        {
            for (int i = 0; i < counter; i++) //cantidad de elementos = cantidad de recorridos
            {
                for (int j = 0; j < counter - i - 1; j++) //j nunca puede valer lo mismo que el tail, porque compara siempre con sí mismo y una posicion despues
                {
                    if (comparison(arrayD[j], arrayD[j + 1]) > 0)
                    {
                        T aux = arrayD[j];
                        arrayD[j] = arrayD[j + 1];
                        arrayD[j + 1] = aux;
                    }
                }
            }
        }

        public void QuickSort(Comparison<T> comparison, T[] array, int low, int high)
        {
            if (low < high)
            {
                int pivot = Partition(comparison, array, low, high);

                QuickSort(comparison, array, low, pivot - 1);
                QuickSort(comparison, array, pivot + 1, high);
            }
        }

        int Partition(Comparison <T> comparison ,T[] array, int low, int high)
        {
            T pivot = array[high];
            int i = low - 1; //cantidad de valores menores al pivot

            for (int j = low; j < high; j++)
            {
                if (comparison(array[j], pivot) < 0)
                {
                    i++;

                    (array[i], array[j]) = (array[j], array[i]);

                }
            }

            (array[i + 1], array[high]) = (array[high], array[i + 1]);

            return i + 1;
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