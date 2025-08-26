using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IItem
{
    public int id { get; set; }
    public int price { get; set; }
    public int rarity { get; set; }
    public string type { get; set; }
    public int quantity { get; set; }
}
