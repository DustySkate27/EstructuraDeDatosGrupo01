using Assets.Grupo_01.TP03.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour
{
    private Button button;
    [SerializeField] private Button activateButton;
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
        item.quantity -= 1;
        Debug.Log(item.quantity.ToString());

        if (item.quantity <= 0)
        {
            item.quantity = 0;
            button.gameObject.SetActive(false);
        }
        if (item.quantity > 0)
        {
            button.gameObject.SetActive(true);
        }
        if(activateButton.gameObject.activeSelf == false)
        {
            activateButton.gameObject.SetActive(true);
        }
    }
}
