using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using Assets.Grupo_01.TP03.Scripts;

public class TP03Executer : MonoBehaviour
{
    [SerializeField] private StoreStock storeStock;
    [SerializeField] private PlayerInventory inventory;
   // [SerializeField] private UIManager uiManager;

    public void BuyItem(int id, int price)
    {
        if(storeStock.stockIn.TryGetValue(id, out ItemSO item) && MoneyManager.Instance.Money > price)
        {
            inventory.AddItem(item);
            storeStock.BuyItem(item);
            MoneyManager.Instance.Buy(price);  
        }
        else
        {
            Debug.Log("SOLD OUT.");
        }
    }

    public void SellItem(int id, int price)
    {
        if (inventory.playerInventory.TryGetValue(id, out ItemSO item))
        {
            inventory.RemoveItem(item);
        }
        else
        {
            Debug.Log("CANT SELL WHAT YOU DONT OWN.");
        }
    }
}
