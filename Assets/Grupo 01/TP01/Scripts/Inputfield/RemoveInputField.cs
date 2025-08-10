using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class RemoveInputField : MonoBehaviour, I_InputField
{
    private TP01Execute mainExecuter;
    public TMP_InputField numbersEntered;

    void Start()
    {
        mainExecuter = GameObject.FindGameObjectWithTag("mainExecuter").GetComponent<TP01Execute>();
        numbersEntered = GetComponent<TMP_InputField>();

        //Agrega una funcion diferente en el evento onEndEdit del inputfield (cuando se clickea) dependiendo del tag que posea el boton

        numbersEntered.onEndEdit.AddListener(OnEndEditAction);
    }

    public void OnEndEditAction(string number) //toma el valor ingresado del inputfield
    {
        int numberInt = Int32.Parse(number); //transforma el valor string del inputfield por un int
        mainExecuter.intList.Remove(numberInt);

        mainExecuter.ShowResult();
    }
}
