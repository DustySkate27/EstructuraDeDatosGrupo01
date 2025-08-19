using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Items;
using UnityEngine;


public class StoreStock : MonoBehaviour
{
    public Dictionary<int, IItem> stockIn = new Dictionary<int, IItem>();
    [SerializeField] private MyList<IItem> itemList;
    private int maxQuantity = 3;

    public void Awake()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            stockIn.Add(itemList[i].id, itemList[i]); //Adds from Inspector List to Dictionary
            stockIn[itemList[i].id].quantity = maxQuantity; //Sets maximal quantity in every item.
        }
    }





}
