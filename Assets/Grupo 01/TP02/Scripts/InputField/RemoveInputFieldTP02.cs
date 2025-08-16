using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RemoveInputFieldTP02 : MonoBehaviour, I_InputField
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
        tp02Executer.myList.Remove(value);
        tp02Executer.ShowResult();
    }
}
