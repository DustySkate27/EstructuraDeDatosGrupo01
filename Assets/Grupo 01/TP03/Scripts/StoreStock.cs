using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class StoreStock : MonoBehaviour
{
    public Dictionary<int, IItem> stockIn = new Dictionary<int, IItem>();
    public int maxQuantity = 3;

    public IItem knife;
    public IItem skull;
    public IItem potion;
    public IItem diamond;
    

    public void Awake()
    {
        knife = new ItemSO(01100, 10, 00, "Weapon", maxQuantity);
        skull = new ItemSO(11501, 15, 01, "Collectible", maxQuantity);
        potion = new ItemSO(23502, 35, 02, "Consumable", maxQuantity);
        diamond = new ItemSO(35003, 50, 03, "Treasure", maxQuantity);

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
