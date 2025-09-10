using SimpleListLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Dictionary<int, IItem> inventory; //Va a ser tipo int, IItems
    [SerializeField] private List<InventoryButtons> buttons;

    public int money = 500;

    
    private List<Vector2> coordinates;

    public Dictionary<int, IItem> Inventory => inventory;

    private void Awake()
    {
        inventory = new Dictionary<int, IItem>();

        coordinates = new List<Vector2>();
        coordinates.Add(new Vector2(-416, -386));
        coordinates.Add(new Vector2(-177, -326));
        coordinates.Add(new Vector2(111, -324));
        coordinates.Add(new Vector2(385, -372));
    }

    public void SortInventory()
    { 

    }

    public int Comparison(int n, int n2)
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
