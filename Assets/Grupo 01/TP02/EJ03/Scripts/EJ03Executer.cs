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
        if (store.Stock.TryGetValue(key, out IItem item))
        {
            if(!player.Inventory.ContainsKey(item.Id))
            {
                player.Inventory.Add(item.Id, item);

            } else Debug.Log("Added!"); //Aumentar la cantidad cuando se agregue

            //store.SellItemOnStock(item);
            player.NewItemOnInv(item);

            store.DisableButtonById(item.Id);
            player.EnableButtonById(item.Id);
        }
        //Debug.Log(key.ToString());        
    }

    public void SellItem(int key)
    {
        player.Inventory.TryGetValue(key, out IItem item);
        if (!store.Stock.ContainsKey(item.Id))
        {
            store.Stock.Add(item.Id, item);
        }
        else Debug.Log("Added!"); //Aumentar la cantidad cuando se agregue

       // player.SellItemOnInv(item);
        store.NewItemOnStock(item);

        player.DisableButtonById(key);
        store.EnableButtonById(key);
    }
}
