
using Assets.Grupo_01.TP03.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Dictionary<int, ItemSO> playerInventory = new Dictionary<int, ItemSO>();

    public int QuantityChecker (int id) //checks for the quantity of the item the player owns
    {
        if (playerInventory.TryGetValue(id, out ItemSO item))
        {
            return item.quantity;
        }
        else
        {
            return 0;
        }

    }

    public void AddItem(ItemSO item)
    {
        if(playerInventory.TryGetValue(item.id, out ItemSO itemCatch))
        {
            playerInventory[item.id].quantity += 1;
        }else 
        playerInventory.Add(item.id, item);
    }
    public void RemoveItem(ItemSO item)
    {
        playerInventory[item.id].quantity -= 1;
    }
}
