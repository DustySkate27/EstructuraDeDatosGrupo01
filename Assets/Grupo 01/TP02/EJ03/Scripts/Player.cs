using SimpleListLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Dictionary<int, IItem> inventory; //Va a ser tipo int, IItems
    private SimpleList<IItem> listHUD; //Va a ser tipo IItems y va a servir para ordenar la interfaz

    public Dictionary<int, IItem> Inventory;

    private void Awake()
    {
        inventory = new Dictionary<int, IItem>();
        listHUD = new SimpleList<IItem>();

    }

    public void NewItemOnInv(IItem item) //Va a ser tipo IItems
    {
        listHUD.Add(item); //asociado al HUD
    }

    public void SellItemOnInv(IItem item)
    {
        listHUD.Remove(item);
    }
}
