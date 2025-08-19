using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Items;

public class Knife : IItem
{
    public int id => 01100;

    public string name => "Knife";

    public int price => 10;

    public int rarity => 00;

    public string type => "Melee";

    public int quantity
    {
        get => quantity;
        set => quantity = value;
    }
}
