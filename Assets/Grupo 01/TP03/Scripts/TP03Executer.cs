using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using System.Globalization;

public class TP03Executer : MonoBehaviour
{
    [SerializeField] private StoreStock storeStock;
    [SerializeField] private PlayerInventory inventory;

    public void BuyItem(int id, int price)
    {
        if(storeStock.stockIn.TryGetValue(id, out IItem item) && MoneyManager.Instance.Money > price)
        {
            switch (inventory.QuantityChecker(id))
            {
                case 0: //first buy.
                    inventory.playerInventory.Add(id, item);
                    storeStock.stockIn[id].quantity--;
                    MoneyManager.Instance.Buy(price);
                    break;
                default: //"while theres stock" buy
                    inventory.playerInventory[id].quantity++;
                    storeStock.stockIn[id].quantity--;
                    MoneyManager.Instance.Buy(price);
                    return;
                case 2: //last buy
                    inventory.playerInventory[id].quantity++;
                    storeStock.stockIn.Remove(id);
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
        if (inventory.playerInventory.TryGetValue(id, out IItem item))
        {
            switch (inventory.QuantityChecker(id))
            {
                case 3: //first buy.
                    storeStock.stockIn.Add(id, item);
                    inventory.playerInventory[id].quantity--;
                    MoneyManager.Instance.Sell(price/2);
                    break;
                default: //"while theres stock" buy
                    storeStock.stockIn[id].quantity++;
                    inventory.playerInventory[id].quantity--;
                    MoneyManager.Instance.Sell(price/2);
                    return;
                case 1: //last buy
                    storeStock.stockIn[id].quantity++;
                    inventory.playerInventory.Remove(id);
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
