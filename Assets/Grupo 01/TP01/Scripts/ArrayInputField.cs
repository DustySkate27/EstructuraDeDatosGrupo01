using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ArrayInputField : MonoBehaviour
{
    private TP01Execute mainExecuter;
    public TMP_InputField numbersEntered;

    void Start()
    {
        mainExecuter = GameObject.FindGameObjectWithTag("mainExecuter").GetComponent<TP01Execute>();
        numbersEntered = GetComponent<TMP_InputField>();

        //Agrega una funcion diferente en el evento onEndEdit del inputfield (cuando se clickea) dependiendo del tag que posea el boton
        //Intentar cambiar esta separacion de funciones de una manera mejor 

        if (gameObject.CompareTag("add"))
        {
            numbersEntered.onEndEdit.AddListener(ReadNumber);
        }
        else if (gameObject.CompareTag("addRange"))
        {
            numbersEntered.onEndEdit.AddListener(ReadArray);
        }
    }

    public void ReadNumber(string numberString) //toma el valor ingresado del inputfield
    {
        int numberInt = Int32.Parse(numberString); //transforma el valor string del inputfield por un int
        mainExecuter.intList.Add(numberInt);

        mainExecuter.ShowValueInConsole();
    }

    public void ReadArray(string numberString) //toma el valor ingresado del inputfield
    {
        if (numberString.Any(char.IsLetter)) //Si se detecta una letra no te deja ingresar el valor 
        {
            Debug.Log("No se pueden ingresar letras"); //Si se detecta una letra no te deja ingresar el valor
            return;
        }

        string[] numbers = numberString.Split(','); //Si detecta una coma separa el valor y lo ingresa al array 
        int[] addToArray = new int[numbers.Length];

        for (int i = 0; i < numbers.Length; i++) //Convierte todos los valores de tipo string dentro del array en int
        {
            addToArray[i] = Int32.Parse(numbers[i]);
        }
        mainExecuter.intList.AddRange(addToArray);

        mainExecuter.ShowValueInConsole();
    }
}
