using SimpleListLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    private Dictionary<int, IItem> stock;
    private SimpleList<IItem> listStock;

    public StoreButton[] buttons;

    public Dictionary<int, IItem> Stock => stock;
    public Item knife;
    public Item skull;
    public Item potion;
    public Item diamond;

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

    public void StoreSortID()
    {
        listStock.BubbleSort(CompareIds);

        for (int i = 0; i < listStock.Count; i++)
        {
            for (int j = 0; j < listStock.Count; j++)
            {
                if (buttons[j].itemId == listStock[i].Id)
                {
                    buttons[j].transform.SetSiblingIndex(i);
                }
            }
            
        }
    }
    public void StoreSortName()
    {
        listStock.BubbleSort(CompareName);

        for (int i = 0; i < listStock.Count; i++)
        {
            for (int j = 0; j < listStock.Count; j++)
            {
                if (buttons[j].itemId == listStock[i].Id)
                {
                    buttons[j].transform.SetSiblingIndex(i);
                }
            }

        }
    }
    public void StoreSortPrice()
    {
        listStock.BubbleSort(ComparePrice);

        for (int i = 0; i < listStock.Count; i++)
        {
            for (int j = 0; j < listStock.Count; j++)
            {
                if (buttons[j].itemId == listStock[i].Id)
                {
                    buttons[j].transform.SetSiblingIndex(i);
                }
            }

        }
    }
    public void StoreSortRarity()
    {
        listStock.BubbleSort(CompareRarity);

        for (int i = 0; i < listStock.Count; i++)
        {
            for (int j = 0; j < listStock.Count; j++)
            {
                if (buttons[j].itemId == listStock[i].Id)
                {
                    buttons[j].transform.SetSiblingIndex(i);
                }
            }

        }
    }
    public void StoreSortType()
    {
        listStock.BubbleSort(CompareType);

        for (int i = 0; i < listStock.Count; i++)
        {
            for (int j = 0; j < listStock.Count; j++)
            {
                if (buttons[j].itemId == listStock[i].Id)
                {
                    buttons[j].transform.SetSiblingIndex(i);
                }
            }

        }
    }


    public int CompareIds(IItem n, IItem n2)
    {
        return n.Id.CompareTo(n2.Id);
    }

    public int CompareName(IItem n, IItem n2)
    {
        return n.ItemName.CompareTo(n2.ItemName);
    }
    public int ComparePrice(IItem n, IItem n2)
    {
        return n.Price.CompareTo(n2.Price);
    }
    public int CompareRarity(IItem n, IItem n2)
    {
        return n.Rarity.CompareTo(n2.Rarity);
    }
    public int CompareType(IItem n, IItem n2)
    {
        return n.Type.CompareTo(n2.Type);
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
