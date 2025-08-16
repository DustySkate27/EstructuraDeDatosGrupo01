using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RemoveAtInputFieldTP02 : MonoBehaviour, I_InputField
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
        int numberInt = int.Parse(value);
        tp02Executer.myList.RemoveAt(numberInt);
        tp02Executer.ShowResult();
    }
}
