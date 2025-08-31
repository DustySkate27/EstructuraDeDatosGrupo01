using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : IItem
{
    public Item(int id, string itemName, int price, int rarity, string type)
    {
        this.id = id;
        this.itemName = itemName;
        this.price = price;
        this.rarity = rarity;
        this.type = type;
    }
    private int id;
    private string itemName;
    private int price;
    private int rarity;
    private string type;
    public int Id { get => id; set => id = value; }
    public string ItemName { get => itemName; set => itemName = value; }
    public int Price { get => price; set => price = value; }
    public int Rarity { get => rarity; set => rarity = value; }
    public string Type { get => type; set => type = value; }

    public int CompareTo(IItem other)
    {
        throw new System.NotImplementedException();
    }
}
