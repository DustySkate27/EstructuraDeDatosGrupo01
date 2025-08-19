using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Items;

public class Potion : IItem
{
    public int id => 03352;

    public string name => "Potion";

    public int price => 35;

    public int rarity => 02;

    public string type => "Consumable";

    public int quantity
    {
        get => quantity;
        set => quantity = value;
    }
}

