using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJ03Executer : MonoBehaviour
{
    private Store store;
    private Player player;

    private void Awake()
    {
        store = new Store();
        player = new Player();
    }

    public void BuyItem(int key)
    {
        store.Stock.TryGetValue(key, out IItem item);
        player.Inventory.Add(item.id, item);

        store.SellItemOnStock(item);
        player.NewItemOnInv(item);
    }

    public void SellItem(int key)
    {
        player.Inventory.TryGetValue(key, out IItem item);
        store.Stock.Add(item.id, item);

        player.SellItemOnInv(item);
        store.NewItemOnStock(item);
    }

}
