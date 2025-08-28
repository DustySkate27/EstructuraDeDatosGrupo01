using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

namespace MyLinkedList
{
    public class MyNode<T>
    {

        private T value;

        public MyNode<T> PrevNode;

        public MyNode<T> NextNode;

        public T Value 
        {
            get => value;
            set => this.value = value;
        }
       


        public MyNode(T value)
        {
            this.value = value;
            NextNode = null;
            PrevNode = null;

        }

        public bool isEquals(T value)
        {

            if (this.value.Equals(value)) return true;
            else return false;

        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
