using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;


namespace Items
{
    public abstract class Item
    {
        public abstract int id { get;}
        public abstract string name { get; }
        public abstract int price { get; }

        private readonly int quantity;
        public abstract int Quantity { get; set; }
        public abstract int rarity { get; }
        public abstract string type { get; }

    }
}
