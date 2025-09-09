using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private Player playerMoney;
    private TextMeshProUGUI textMeshProUGUI;
    private void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        MoneyTextUpdate(playerMoney.money);
    }

    public void MoneyTextUpdate(int money)
    {
        textMeshProUGUI.text = money.ToString();
    }
}
