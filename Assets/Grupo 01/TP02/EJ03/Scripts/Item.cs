using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour, IItem
{
    public Item(int id, string itemName, int price, int rarity, string type)
    {
        this.id = id;
        this.itemName = itemName;
        this.price = price;
        this.rarity = rarity;
        this.type = type;
    }

    public int id { get => id; set => id = value; }
    public string itemName { get => itemName; set => itemName = value; }
    public int price { get => price; set => price = value; }
    public int rarity { get => rarity; set => rarity = value; }
    public string type { get => type; set => type = value; }

    public int CompareTo(IItem other)
    {
        throw new System.NotImplementedException();
    }
}
