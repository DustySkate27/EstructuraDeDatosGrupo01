using SimpleListLibrary;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Dictionary<int, IItem> inventory; //Va a ser tipo int, IItems
    private SimpleList<IItem> listInventory;

    [SerializeField] private InventoryButtons[] buttons;

    public int money = 500;

    public Item knife;
    public Item skull;
    public Item potion;
    public Item diamond;

    public Dictionary<int, IItem> Inventory => inventory;

    private void Awake()
    {
        inventory = new Dictionary<int, IItem>();

        knife = new Item(1, "knife", 10, 0, "melee", 3);
        skull = new Item(2, "skull", 5, 1, "collectable", 3);
        potion = new Item(3, "potion", 30, 2, "consumable", 3);
        diamond = new Item(4, "diamond", 100, 3, "gem", 3);

        listInventory = new SimpleList<IItem>();

        listInventory.Add(knife);
        listInventory.Add(skull);
        listInventory.Add(potion);
        listInventory.Add(diamond);


    }

    public void StoreSortID()
    {
        listInventory.BubbleSort(CompareIds);

        for (int i = 0; i < listInventory.Count; i++)
        {
            for (int j = 0; j < listInventory.Count; j++)
            {
                if (buttons[j].itemId == listInventory[i].Id)
                {
                    buttons[j].transform.SetSiblingIndex(i);
                }
            }

        }
    }
    public void StoreSortName()
    {
        listInventory.BubbleSort(CompareName);

        for (int i = 0; i < listInventory.Count; i++)
        {
            for (int j = 0; j < listInventory.Count; j++)
            {
                if (buttons[j].itemId == listInventory[i].Id)
                {
                    buttons[j].transform.SetSiblingIndex(i);
                }
            }

        }
    }
    public void StoreSortPrice()
    {
        listInventory.BubbleSort(ComparePrice);

        for (int i = 0; i < listInventory.Count; i++)
        {
            for (int j = 0; j < listInventory.Count; j++)
            {
                if (buttons[j].itemId == listInventory[i].Id)
                {
                    buttons[j].transform.SetSiblingIndex(i);
                }
            }

        }
    }
    public void StoreSortRarity()
    {
        listInventory.BubbleSort(CompareRarity);

        for (int i = 0; i < listInventory.Count; i++)
        {
            for (int j = 0; j < listInventory.Count; j++)
            {
                if (buttons[j].itemId == listInventory[i].Id)
                {
                    buttons[j].transform.SetSiblingIndex(i);
                }
            }

        }
    }
    public void StoreSortType()
    {
        listInventory.BubbleSort(CompareType);

        for (int i = 0; i < listInventory.Count; i++)
        {
            for (int j = 0; j < listInventory.Count; j++)
            {
                if (buttons[j].itemId == listInventory[i].Id)
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
