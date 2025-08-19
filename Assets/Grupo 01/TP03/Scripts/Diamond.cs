using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Items;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Diamond : IItem
{
    public int id => 04503;

    public string name => "Diamond";

    public int price => 50;

    public int rarity => 03;

    public string type => "Collectible";

    public int quantity
    {
        get => quantity;
        set => quantity = value;
    }
}
