using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AddRangeInputFieldTP02 : MonoBehaviour, I_InputField
{
    private TP02Executer tp02Executer;
    public TMP_InputField numbersEntered;

    private void Awake()
    {
        tp02Executer = GameObject.FindGameObjectWithTag("mainExecuter").GetComponent<TP02Executer>();
        numbersEntered = GetComponent<TMP_InputField>();

        //Agrega una funcion diferente en el evento onEndEdit del inputfield (cuando se clickea) dependiendo del tag que posea el boton

        numbersEntered.onEndEdit.AddListener(OnEndEditAction);
    }

    public void OnEndEditAction(string value)
    {
        string[] fullValue = value.Split(','); //Si detecta una coma separa el valor y lo ingresa al array 

        tp02Executer.myList.AddRange(fullValue);
        tp02Executer .ShowResult();
    }
}
