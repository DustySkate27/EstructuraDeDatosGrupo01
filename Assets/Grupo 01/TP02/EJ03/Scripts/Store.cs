using SimpleListLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    private Dictionary<int, IItem> stock; //Va a ser tipo int, IItems
    private SimpleList<IItem> listHUD;

    public Dictionary<int, IItem> Stock;
    private Item knife;
    private Item skull;
    private Item potion;
    private Item diamond;

    private void Awake()
    {
        stock = new Dictionary<int, IItem>();
        listHUD = new SimpleList<IItem>();

        knife = new Item(1, "knife", 10, 0, "melee");
        skull = new Item(2, "skull", 5, 1, "collectable");
        potion = new Item(3, "potion", 30, 2, "consumable");
        diamond = new Item(4, "diamond", 100, 3, "gem");

        stock.Add(knife.id ,knife);
        stock.Add(skull.id ,skull);
        stock.Add(potion.id ,potion);
        stock.Add(diamond.id ,diamond);

        NewItemOnStock(knife);
        NewItemOnStock(skull);
        NewItemOnStock(potion);
        NewItemOnStock(diamond);
    }
    public void NewItemOnStock(IItem item) //for visual purposes
    {
        listHUD.Add(item); //asociado al HUD
    }

    public void SellItemOnStock(IItem item)
    {
        listHUD.Remove(item);
    }
}
