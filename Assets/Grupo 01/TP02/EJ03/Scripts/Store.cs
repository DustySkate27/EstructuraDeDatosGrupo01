using SimpleListLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    private Dictionary<int, IItem> stock;
    private SimpleList<IItem> listStock;

    //public List<IItem> ListStock => listStock;
    public Dictionary<int, IItem> Stock => stock;
    public Item knife;
    public Item skull;
    public Item potion;
    public Item diamond;

    [SerializeField] private List<StoreButton> buttons;

    private void Awake()
    {
        stock = new Dictionary<int, IItem>();

        knife = new Item(1, "knife", 10, 0, "melee",3);
        skull = new Item(2, "skull", 5, 1, "collectable", 3);
        potion = new Item(3, "potion", 30, 2, "consumable", 3);
        diamond = new Item(4, "diamond", 100, 3, "gem", 3);

        stock.Add(knife.Id ,knife);
        stock.Add(skull.Id ,skull);
        stock.Add(potion.Id ,potion);
        stock.Add(diamond.Id, diamond); 

        listStock = new SimpleList<IItem>();

        listStock.Add(knife);
        listStock.Add(skull);
        listStock.Add(potion);
        listStock.Add(diamond);
    }

    public void StoreSort(SimpleList<IItem> items)
    {
        for (int i = 0;  i < items.Count; i++)
        {
            items.BubbleSort();//COMO SE PASA UN COMPARISON
        }
    }

    public int CompareIds(int n, int n2)
    {
        return n.CompareTo(n2);
    }

    public int Comparison(string name, string name2)
    {
        return name.CompareTo(name2);
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
