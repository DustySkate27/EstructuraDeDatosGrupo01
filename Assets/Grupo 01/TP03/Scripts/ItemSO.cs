using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObject/ItemSO")]
public class ItemSO : ScriptableObject
{
    public IItem item;

    public int id {  get => id; set => id = value; }
    public int price { get=> price; set => price = value; }

    public int rarity { get => rarity; set => rarity = value; }

    public string type { get => type; set => type = value; }

    public int quantity { get => quantity; set => quantity = value; }

    public ItemSO(int id, int price, int rarity, string type, int quantity)
    {
        this.id = id;
        this.price = price;
        this.rarity = rarity;
        this.type = type;
        this.quantity = quantity;
    }
}
