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
        private MyNode<T> prevNode, nextNode;

        public MyNode<T> PrevNode { 
            get { return prevNode; }
            set { prevNode = value; }
        }

        public MyNode<T> NextNode { 
            get { return nextNode; }
            set { nextNode = value; }
        }

        public T Value { 
            get { return value; } 
            set { this.value = Value; }    
        }
       


        public MyNode(T value)
        {
            this.value = value;
            nextNode = null;
            prevNode = null;

        }

        public bool isEquals(T value)
        {

            if (this.value.Equals(value)) return true;
            else return false;

        }

        public override string ToString()
        {
            string text = "";

            text += value.ToString();

            return text;

        }
    }
}
