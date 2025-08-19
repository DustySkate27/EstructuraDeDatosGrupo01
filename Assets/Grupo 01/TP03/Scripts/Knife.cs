using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Items;

public class Knife : Item
{
    public override int id => 01100;

    public override string name => "Knife";

    public override int price => 10;

    public override int rarity => 00;

    public override string type => "Melee";

    private int quantity;

    public override int Quantity
    {
        get => quantity;
        set => quantity = value;
    }
}
