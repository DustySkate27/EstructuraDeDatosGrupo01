using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class StoreStock : MonoBehaviour
{
    public Dictionary<int, ItemSO> stockIn = new Dictionary<int, ItemSO>();
    public int maxQuantity = 3;

    public ItemSO knife;
    public ItemSO skull;
    public ItemSO potion;
    public ItemSO diamond;
    

    public void Awake()
    {
        knife = new ItemSO(01100, 10, 0, "Weapon", maxQuantity);
        skull = new ItemSO(11501, 15, 1, "Collectible", maxQuantity);
        potion = new ItemSO(23502, 35, 2, "Consumable", maxQuantity);
        diamond = new ItemSO(35003, 50, 3, "Treasure", maxQuantity);

        stockIn.Add(knife.id, knife);
        stockIn.Add(potion.id, potion); 
        stockIn.Add(skull.id, skull);
        stockIn.Add(diamond.id, diamond);

        stockIn[knife.id].quantity = maxQuantity;
        stockIn[skull.id].quantity = maxQuantity;
        stockIn[potion.id].quantity = maxQuantity;
        stockIn[diamond.id].quantity = maxQuantity;

    }





}
