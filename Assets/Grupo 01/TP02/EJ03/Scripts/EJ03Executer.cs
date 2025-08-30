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
        store.Stock.TryGetValue(key, out int item);
    }

}
