using SimpleListLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Dictionary<int, IItem> inventory; //Va a ser tipo int, IItems
    public SortableSimpleList<IItem> listHUD; //Va a ser tipo IItems y va a servir para ordenar la interfaz
    [SerializeField] private List<InventoryButtons> buttons;
    

    public Dictionary<int, IItem> Inventory => inventory;

    private void Awake()
    {
        inventory = new Dictionary<int, IItem>();
        listHUD = new SortableSimpleList<IItem>();
        
    }

    public void NewItemOnInv(IItem item) //Va a ser tipo IItems
    {
        listHUD.Add(item); //asociado al HUD

    }

    public void SellItemOnInv(IItem item)
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
