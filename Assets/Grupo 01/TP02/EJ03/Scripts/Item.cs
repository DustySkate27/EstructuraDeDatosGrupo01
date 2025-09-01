using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : IItem
{
    public Item(int id, string itemName, int price, int rarity, string type, int quantity)
    {
        this.id = id;
        this.itemName = itemName;
        this.price = price;
        this.rarity = rarity;
        this.type = type;
        this.quantity = quantity;
    }
    private int id;
    private string itemName;
    private int price;
    private int rarity;
    private string type;
    private int quantity;
    public int Id { get => id; set => id = value; }
    public string ItemName { get => itemName; set => itemName = value; }
    public int Price { get => price; set => price = value; }
    public int Rarity { get => rarity; set => rarity = value; }
    public string Type { get => type; set => type = value; }
    public int Quantity { get => quantity; set => quantity = value; }

    public int CompareTo(IItem other)
    {
        throw new System.NotImplementedException();
    }
}
