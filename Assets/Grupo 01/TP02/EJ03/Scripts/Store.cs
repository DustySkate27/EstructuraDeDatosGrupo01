using SimpleListLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public Dictionary<int, IItem> stock; //Va a ser tipo int, IItems
    public SortableSimpleList<IItem> listHUD;

    public Dictionary<int, IItem> Stock => stock;
    public Item knife;
    public Item skull;
    public Item potion;
    public Item diamond;

    [SerializeField] private List<StoreButton> buttons;

    private void Start()
    {
        stock = new Dictionary<int, IItem>();
        listHUD = new SortableSimpleList<IItem>();

        knife = new Item(1, "knife", 10, 0, "melee");
        skull = new Item(2, "skull", 5, 1, "collectable");
        potion = new Item(3, "potion", 30, 2, "consumable");
        diamond = new Item(4, "diamond", 100, 3, "gem");

        stock.Add(knife.Id ,knife);
        stock.Add(skull.Id ,skull);
        stock.Add(potion.Id ,potion);
        stock.Add(diamond.Id ,diamond);

        NewItemOnStock(knife);
        NewItemOnStock(skull);
        NewItemOnStock(potion);
        NewItemOnStock(diamond);
    }
    public void NewItemOnStock(IItem item) //for visual purposes
    {
        listHUD.Add(item); //asociado al HUD
        Debug.Log(item.ItemName + " " + item.Id);
    }

    public void SellItemOnStock(IItem item)
    {
        listHUD.Remove(item);
    }

    public void DisableButtonById(int id)
    {
        foreach (var btn in buttons)
        {
            if (btn.itemId == id)
            {
                btn.DisableButton();
                break;
            }
        }
    }
    public void EnableButtonById(int id)
    {
        foreach (var btn in buttons)
        {
            if (btn.itemId == id)
            {
                btn.EnableButton();
                break;
            }
        }
    }
}
