using Assets.Grupo_01.TP03.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class StoreStock : MonoBehaviour
{
    [SerializeField] public Dictionary<int, ItemSO> stockIn = new Dictionary<int, ItemSO>();
    [SerializeField] public ItemListSO itemLister;
    public int maxQuantity = 3;
    

    public void Awake()
    {
        foreach(ItemSO item in itemLister.itemList)
        {
            stockIn.Add(item.id, item);
        }
    }
    public void BuyItem(ItemSO item)
    {
        item.quantity -= 1;
        //Debug.Log(item.storeQuantity.ToString());
    }
    public void RecoverItem(ItemSO item)
    {
        item.quantity += 1;
        Debug.Log("Sotre got it´s item back");
    }




}
