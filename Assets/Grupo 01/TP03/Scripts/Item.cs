using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;


namespace Items
{
    public interface IItem
    {
        int id { get;}
        string name { get; }
        int price { get; }
        int quantity { get; set; }
        int rarity { get; }
        string type { get; }

        string ToString();
    }
}
