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

    public Dictionary<int, IItem> Inventory => inventory;

    private void Awake()
    {
        inventory = new Dictionary<int, IItem>();        
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
