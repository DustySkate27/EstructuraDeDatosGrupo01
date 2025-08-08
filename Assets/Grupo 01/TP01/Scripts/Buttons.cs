using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private TP01Execute mainExecuter;

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        mainExecuter = GameObject.FindGameObjectWithTag("mainExecuter").GetComponent<TP01Execute>();

        button = GetComponent<Button>();

        //Agrega una funcion diferente en el evento onclick del boton (cuando se clickea) dependiendo del tag que posea el boton
        //Intentar cambiar esta separacion de funciones de una manera mejor 

        if (gameObject.CompareTag("remove"))
        {
            button.onClick.AddListener(RemoveNumber);
        }
        else if (gameObject.CompareTag("clear"))
        {
            button.onClick.AddListener(ClearArray);
        }

    }
    public void RemoveNumber() //Funcion remove
    {
        mainExecuter.intList.Remove(mainExecuter.intList.arrayD.Length - 1);

        mainExecuter.ShowValueInConsole();
    }

    public void ClearArray() //Funcion clear
    {
        mainExecuter.intList.Clear();

        mainExecuter.ShowValueInConsole();
    }
}
