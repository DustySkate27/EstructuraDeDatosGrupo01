using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObject/ItemSO")]
public class ItemSO : ScriptableObject
{
    public IItem item;

    public int id;

    public int price;

    public int rarity;

    public string type;

    public int quantity;


    public ItemSO(int id, int price, int rarity, string type, int quantity)
    {
        this.id = id;
        this.price = price;
        this.rarity = rarity;
        this.type = type;
        this.quantity = quantity;
    }
}
