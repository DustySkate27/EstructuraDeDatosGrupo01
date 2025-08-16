using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddListInputFieldTP02 : MonoBehaviour, I_InputField
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
        MyList<string> list = new MyList<string>();
        string[] fullValue = value.Split(','); //Si detecta una coma separa el valor y lo ingresa al array 

        for (int i = 0;  i < fullValue.Length; i++)
        {
            list.Add(fullValue[i]);
        }

        tp02Executer.myList.AddRange(list);
        tp02Executer.ShowResult();
    }
}
