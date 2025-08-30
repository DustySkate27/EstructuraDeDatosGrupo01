using SimpleListLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Dictionary<int, int> inventory; //Va a ser tipo int, IItems
    private SimpleList<int> listHUD; //Va a ser tipo IItems y va a servir para ordenar la interfaz

    public Dictionary<int, int> Inventory;

    private void Awake()
    {
        inventory = new Dictionary<int, int>();
        listHUD = new SimpleList<int>();

    }

    public void NewItemOnInv(int newItem, int associatedKey) //Va a ser tipo IItems
    {
        listHUD.Add(newItem); //asociado al HUD
    }

    public void SellItemOnInv(int item, int associatedKey)
    {
        listHUD.Remove(item);
    }
}
