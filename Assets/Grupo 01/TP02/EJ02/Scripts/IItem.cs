using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IItem : IComparable<IItem>
{
    int id { get; set; }
    string itemName { get; set; }
    int price { get; set; }
    int rarity { get; set; }
    string type {  get; set; }

}
