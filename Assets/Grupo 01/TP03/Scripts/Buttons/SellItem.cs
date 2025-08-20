using Assets.Grupo_01.TP03.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellItem : MonoBehaviour
{
    private Button button;
    [SerializeField] private ItemSO item;
    [SerializeField] private Button activateButton;
    [SerializeField] TP03Executer TP03Executer;


    // Start is called before the first frame update
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        button.gameObject.SetActive(false);
    }

    public void OnClick()
    {
        TP03Executer.SellItem(item.id, item.price);

        if (item.quantity < 0)
        {
            item.quantity = 0;
            button.gameObject.SetActive(false);
        }
        if(item.quantity > 0)
        {
            button.gameObject.SetActive(true);
        }
        if (activateButton.gameObject.activeSelf == false)
        {
            activateButton.gameObject.SetActive(true);
        }
    }
}
