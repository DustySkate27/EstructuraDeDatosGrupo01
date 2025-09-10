using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButtons : MonoBehaviour
{
    [SerializeField] Button selfButton;
    public int itemId;
    void Awake()
    {
        selfButton = GetComponent<Button>();
        selfButton.interactable = false;
    }
    public void EnableButton() 
    {
        selfButton.interactable = true;

    }

    public void DisableButton()
    {
        selfButton.interactable = false;
    }
}
