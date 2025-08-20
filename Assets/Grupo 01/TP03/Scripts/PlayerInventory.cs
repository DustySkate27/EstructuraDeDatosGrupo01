
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Dictionary<int, ItemSO> playerInventory = new Dictionary<int, ItemSO>();

    public int Count
    {
        get => playerInventory.Count;
    }

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
}
