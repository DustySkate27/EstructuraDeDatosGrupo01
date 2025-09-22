using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EJ03Executer : MonoBehaviour
{
    [SerializeField] private Store store;
    [SerializeField] private Player player;
    [SerializeField] private MoneyUI moneyUI;

    public void BuyItem(int key) //key == item.Id; Assigned through Inspector
    {
        if (player.money < store.Stock[key].Price) //If there isn't money
        {
            Debug.Log("No tienes suficiente dinero");
            return;
        }

        if (store.Stock.TryGetValue(key, out IItem item)) //Checks if there's clicked item
        {

            if (!player.Inventory.ContainsKey(key))
            {
                player.Inventory.Add(key, new Item(item.Id, item.ItemName, item.Price, item.Rarity, item.Type, item.Quantity));
                player.Inventory[key].Quantity = 1;
                player.EnableButtonById(key);
            }
            else
            {
                player.Inventory[key].Quantity += 1;
            }

            
            store.Stock[key].Quantity -= 1;

            if (store.Stock[key].Quantity <= 0)
            {
                store.Stock.Remove(key);
                store.DisableButtonById(key);
            }

            player.money -= item.Price;

            moneyUI.MoneyTextUpdate(player.money);
        }
    }

    public void SellItem(int key)
    {
        if (player.Inventory.TryGetValue(key, out IItem item))
        {

            if (!store.Stock.ContainsKey(key))
            {
                store.Stock.Add(key, new Item(item.Id, item.ItemName, item.Price, item.Rarity, item.Type, item.Quantity));
                store.Stock[key].Quantity = 1;
                store.EnableButtonById(key);
            }
            else
            {
                store.Stock[key].Quantity += 1;
            }

            player.Inventory[key].Quantity -= 1;


            if (player.Inventory[key].Quantity <= 0)
            { 
                player.Inventory.Remove(key);
                player.DisableButtonById(key);
            }

            player.money += item.Price/2;

            moneyUI.MoneyTextUpdate(player.money);
        }
        else
        {
            Debug.Log("No tienes este item para vender.");
        }
    }

}
