using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EJ03Executer : MonoBehaviour
{
    [SerializeField] private Store store;
    [SerializeField] private Player player;
    [SerializeField] private MoneyUI moneyUI;

    private void Awake()
    {

    }

    public int Comparison(int n, int n2)
    {
        return n.CompareTo(n2);
    }

    public int Comparison(string name, string name2)
    {
        return name.CompareTo(name2);
    }

    public void BuyItem(int key)
    {
        Debug.Log(store.Stock[key].Quantity.ToString());

        if (player.money < store.Stock[key].Price)
        {
            Debug.Log("No tienes suficiente dinero");
            return;
        }

        if (store.Stock.TryGetValue(key, out IItem item))
        {
            Debug.Log(!player.Inventory.ContainsKey(item.Id));
            if (!player.Inventory.ContainsKey(item.Id))
            {//El problema es que las cantidades se estan reseteando
                player.Inventory.Add(item.Id, item);
                Debug.Log(player.Inventory[key].Quantity.ToString());
                player.Inventory[key].Quantity = 1;
                player.EnableButtonById(item.Id);
            }//SO, escucha, lo que tenes que hacer es lograr que store no resetee su valor de quantity, pero si resetee le de inventory
            else
            {
                player.Inventory[item.Id].Quantity += 1;
            }

            store.Stock[key].Quantity -= 1;//posiblemente, este es el problema

            if (store.Stock[key].Quantity <= 0)//y esta es la consecuencia del mismo
            {
                store.Stock.Remove(key);
                store.DisableButtonById(item.Id);
            }

            player.money -= item.Price;//AL menos, este funciona

            moneyUI.MoneyTextUpdate(player.money);//Como diria el gay, JUANA ROZAS
        }
    }

    public void SellItem(int key)
    {
        if (player.Inventory.TryGetValue(key, out IItem item))
        {
            Debug.Log(!store.Stock.ContainsKey(item.Id));
            if (!store.Stock.ContainsKey(item.Id))
            {
                store.Stock.Add(item.Id, item);
                store.Stock[key].Quantity = 1;
                store.EnableButtonById(item.Id);
            }
            else
            {
                store.Stock[item.Id].Quantity += 1;
            }

            player.Inventory[item.Id].Quantity -= 1;


            if (player.Inventory[item.Id].Quantity <= 0)
            { 
                player.Inventory.Remove(item.Id);
                player.DisableButtonById(item.Id);
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
