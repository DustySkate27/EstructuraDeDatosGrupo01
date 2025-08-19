using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using System.Globalization;

public class TP03Executer : MonoBehaviour
{
    [SerializeField] private StoreStock storeStock;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private UIManager uiManager;

    public void BuyItem(int id, int price)
    {
        if(storeStock.stockIn.TryGetValue(id, out Item item) && MoneyManager.Instance.Money > price)
        {
            switch (inventory.QuantityChecker(id))
            {
                case 0: //first buy.
                    inventory.playerInventory.Add(id, item);
                    storeStock.stockIn[id].Quantity--;
                    uiManager.BuyActivator(id);
                    MoneyManager.Instance.Buy(price);
                    break;
                default: //"while theres stock" buy
                    inventory.playerInventory[id].Quantity++;
                    storeStock.stockIn[id].Quantity--;
                    MoneyManager.Instance.Buy(price);
                    return;
                case 2: //last buy
                    inventory.playerInventory[id].Quantity++;
                    storeStock.stockIn.Remove(id);
                    uiManager.BuyDeactivator(id);
                    MoneyManager.Instance.Buy(price);
                    break;
            }
            
        }
        else
        {
            Debug.Log("This item has already been sold out.");
        }
    }

    public void SellItem(int id, int price)
    {
        if (inventory.playerInventory.TryGetValue(id, out   Item item))
        {
            switch (inventory.QuantityChecker(id))
            {
                case 3: //first buy.
                    storeStock.stockIn.Add(id, item);
                    inventory.playerInventory[id].Quantity--;
                    uiManager.sellActivator(id);
                    MoneyManager.Instance.Sell(price/2);
                    break;
                default: //"while theres stock" buy
                    storeStock.stockIn[id].Quantity++;
                    inventory.playerInventory[id].Quantity--;
                    MoneyManager.Instance.Sell(price/2);
                    return;
                case 1: //last buy
                    storeStock.stockIn[id].Quantity++;
                    inventory.playerInventory.Remove(id);
                    uiManager.SellDeactivator(id);
                    MoneyManager.Instance.Sell(price/2);
                    break;
            }

        }
        else
        {
            Debug.Log("This item has already been fully bought.");
        }
    }
}
