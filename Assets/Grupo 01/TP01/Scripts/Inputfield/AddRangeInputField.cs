using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class AddRangeInputField : MonoBehaviour, I_InputField
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
        if (number.Any(char.IsLetter)) //Si se detecta una letra no te deja ingresar el valor 
        {
            Debug.Log("No se pueden ingresar letras"); //Si se detecta una letra no te deja ingresar el valor
            return;
        }

        string[] fullNumbers = number.Split(','); //Si detecta una coma separa el valor y lo ingresa al array 
        int[] addToArray = new int[fullNumbers.Length];

        for (int i = 0; i < fullNumbers.Length; i++) //Convierte todos los valores de tipo string dentro del array en int
        {
            addToArray[i] = Int32.Parse(fullNumbers[i]);
        }
        mainExecuter.intList.AddRange(addToArray);

        mainExecuter.ShowValue();
    }
}
