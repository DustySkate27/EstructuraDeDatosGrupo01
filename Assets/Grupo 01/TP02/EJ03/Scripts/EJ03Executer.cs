using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJ03Executer : MonoBehaviour
{
    [SerializeField] private Store store;
    [SerializeField] private Player player;

    private void Awake()
    {

    }

    public void BuyItem(int key)
    {
        if (player.money < store.Stock[key].Price)
        {
            Debug.Log("No tienes suficiente dinero");
            return;
        }

        if (store.Stock.TryGetValue(key, out IItem item))
        {

            if (!player.Inventory.ContainsKey(item.Id))
            {
                IItem newItem = new Item(item.Id, item.ItemName, item.Price, item.Rarity, item.Type, 1);
                player.Inventory.Add(newItem.Id, newItem);
            }
            else
            {
                player.Inventory[item.Id].Quantity += 1;
            }

            player.money -= item.Price;

            store.Stock[key].Quantity -= 1;

           /* Debug.Log($"Compraste {item.ItemName}. " +
                      $"Cantidad en player: {player.Inventory[item.Id].Quantity}, " +
                      $"Cantidad en tienda: {store.Stock[key].Quantity}");*/

            if (store.Stock[key].Quantity <= 0)
            {
                store.DisableButtonById(item.Id);
            }

            player.EnableButtonById(item.Id);
        }
    }

    public void SellItem(int key)
    {
        if (player.Inventory.TryGetValue(key, out IItem item))
        {

            if (!store.Stock.ContainsKey(item.Id))
            {
                IItem newItem = new Item(item.Id, item.ItemName, item.Price, item.Rarity, item.Type, 1);
                store.Stock.Add(newItem.Id, newItem);
            }
            else
            {

                store.Stock[item.Id].Quantity += 1;
            }

            player.Inventory[item.Id].Quantity -= 1;

           /* Debug.Log($"Vendiste {item.ItemName}. " +
                      $"Cantidad en player: {player.Inventory[item.Id].Quantity}, " +
                      $"Cantidad en tienda: {store.Stock[item.Id].Quantity}");*/


            if (player.Inventory[item.Id].Quantity <= 0)
            {
                player.DisableButtonById(item.Id);
            }

            store.EnableButtonById(item.Id);

            player.money += item.Price;
        }
        else
        {
            Debug.Log("No tienes este item para vender.");
        }
    }

}
