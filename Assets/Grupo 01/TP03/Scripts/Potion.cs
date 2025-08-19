using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Items;

public class Potion : Item
{
    public override int id => 03352;

    public override string name => "Potion";

    public override int price => 35;

    public override int rarity => 02;

    public override string type => "Consumable";

    private int quantity;

    public override int Quantity
    {
        get => quantity;
        set => quantity = value;
    }
}

