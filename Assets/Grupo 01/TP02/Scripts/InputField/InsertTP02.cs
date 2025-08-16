using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InsertTP02 : MonoBehaviour, I_InputField
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

        if (fullValue.Length > 2)
        {
            Debug.Log("Mas valores de los requeridos");
            return;
        }

        if (fullValue[0].Any(char.IsLetter)) //Si se detecta una letra no te deja ingresar el valor 
        {
            Debug.Log("No se pueden ingresar letras como valor de index"); //Si se detecta una letra no te deja ingresar el valor
            return;
        }

        int index = int.Parse(fullValue[0]);

        tp02Executer.myList.Insert(index, fullValue[1]);
        tp02Executer.ShowResult();
    }
}
