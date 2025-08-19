using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Items;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Diamond : Item
{
    public override int id => 04503;

    public override string name => "Diamond";

    public override int price => 50;

    public override int rarity => 03;

    public override string type => "Collectible";

    private int quantity;

    public override int Quantity
    {
        get => quantity;
        set => quantity = value;
    }
}
