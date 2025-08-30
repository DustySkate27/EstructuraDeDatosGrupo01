using SimpleListLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    private Dictionary<int, IItem> stock; //Va a ser tipo int, IItems
    private SimpleList<IItem> listHUD;

    public Dictionary<int, IItem> Stock;

    private void Awake()
    {
        stock = new Dictionary<int, IItem>();
        listHUD = new SimpleList<IItem>();
        stock.Add(0,);
        stock.Add(1,1);
        stock.Add(2,2);
        stock.Add(3,3);
    }
    public void NewItemOnStock(int newItem, int associatedKey) //Va a ser tipo IItems
    {
        listHUD.Add(newItem); //asociado al HUD
    }

    public void SellItemOnStock(int item, int associatedKey)
    {
        listHUD.Remove(item);
    }
}
