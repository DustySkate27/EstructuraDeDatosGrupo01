using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Items;

public class Skull : IItem
{
    public int id => 02151;

    public string name => "Skull";

    public int price => 15;

    public int rarity => 01;

    public string type => "Collectible";

    public int quantity
    {
        get => quantity;
        set => quantity = value;
    }
}

