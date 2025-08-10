using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class TP01Execute : MonoBehaviour
{
    public SimpleList<int> intList = new SimpleList<int>();
    private TextRefresher texts;


    void Start()
    {

        texts = GameObject.FindGameObjectWithTag("resultText").GetComponent<TextRefresher>();  
        
        ShowValue();
        
    }

    public void ShowValue() //Actuliza el array en consola y en escena
    {
        Debug.Log(intList.ToString());

        texts.ArrayUpdate();
    }
}
