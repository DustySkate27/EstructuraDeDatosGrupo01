using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Items;

public class Skull : Item
{
    public override int id => 02151;

    public override string name => "Skull";

    public override int price => 15;

    public override int rarity => 01;

    public override string type => "Collectible";

    private int quantity;

    public override int Quantity
    {
        get => quantity;
        set => quantity = value;
    }
}

