
using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class TP01Execute : MonoBehaviour
{
    public SimpleList<int> intList = new SimpleList<int>();
    private Texts texts;


    void Start()
    {
        intList.Add(0);
        intList.Add(1);
        intList.Add(2);
        intList.Add(6);

        texts = GameObject.FindGameObjectWithTag("resultText").GetComponent<Texts>();

        ShowValueInConsole();
        
              
    }

    public void ShowValueInConsole() //Actuliza el array en consola y en escena
    {
        Debug.Log(intList.ToString());

        //La funcion de texts no funcion actualmente
        texts.ArrayUpdate();
    }
}
