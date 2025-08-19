using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkullSellButton : MonoBehaviour
{
    private Button button;
    [SerializeField] TP03Executer TP03Executer;

    // Start is called before the first frame update
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        TP03Executer.SellItem(02151, 15);
    }
}
