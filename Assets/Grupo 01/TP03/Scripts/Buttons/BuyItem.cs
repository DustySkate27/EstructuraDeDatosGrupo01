using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour
{
    private Button button;
    [SerializeField] ItemSO item;
    [SerializeField] TP03Executer TP03Executer;

    // Start is called before the first frame update
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        TP03Executer.BuyItem(item.id, item.price);
    }
}
