using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class PlayerInventory : MonoBehaviour
{
    public Dictionary<int, Item> playerInventory = new Dictionary<int, Item>();

    public int Count
    {
        get => playerInventory.Count;
    }

    public int QuantityChecker (int id) //checks for the quantity of the item the player owns
    {
        if (playerInventory.TryGetValue(id, out Item item))
        {
            return item.Quantity;
        }
        else
        {
            return 0;
        }

    }
}
