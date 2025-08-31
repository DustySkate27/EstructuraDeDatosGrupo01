using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IItem : IComparable<IItem>
{

    int Id { get; set; }
    string ItemName { get; set; }
    int Price { get; set; }
    int Rarity { get; set; }
    string Type {  get; set; }

}
