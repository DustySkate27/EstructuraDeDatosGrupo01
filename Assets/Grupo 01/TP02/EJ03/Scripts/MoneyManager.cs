using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance { get; private set; }

    private int money = 500;

    public int Money => money;

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void Buy(int itemPrice)
    {
        money -= itemPrice;
    }

    public void Sell(int itemPrice)
    {
        money += itemPrice;
    }
}
