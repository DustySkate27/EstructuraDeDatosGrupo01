using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Items;
using UnityEngine;
using UnityEngine.UI;


public class StoreStock : MonoBehaviour
{
    public Dictionary<int, Item> stockIn = new Dictionary<int, Item>();
    private int maxQuantity = 3;

    private Skull skull = new Skull();
    private Knife knife = new Knife();
    private Diamond diamond = new Diamond();
    private Potion potion = new Potion();

    public void Awake()
    {
        stockIn.Add(knife.id, knife);
        stockIn.Add(potion.id, potion); 
        stockIn.Add(skull.id, skull);
        stockIn.Add(diamond.id, diamond);

        stockIn[knife.id].Quantity = maxQuantity;
        stockIn[skull.id].Quantity = maxQuantity;
        stockIn[potion.id].Quantity = maxQuantity;
        stockIn[diamond.id].Quantity = maxQuantity;

    }





}
