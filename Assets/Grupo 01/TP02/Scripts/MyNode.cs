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
        private int nextIndex, prevIndex, index;

        public MyNode(T value,int prevIndex, int nextIndex, int index)
        {
            this.value = value;
            this.index = index; 
            this.nextIndex = nextIndex;
            this.prevIndex = prevIndex;
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
