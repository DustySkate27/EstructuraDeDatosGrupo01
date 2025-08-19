using SimpleListLibrary;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class TP01Execute : MonoBehaviour
{
    public SimpleList<int> intList = new SimpleList<int>();
    private TextRefresher resultText;
    private TextCounter counterText;


    void Start()
    {
        resultText = GameObject.FindGameObjectWithTag("resultText").GetComponent<TextRefresher>();
        counterText = GameObject.FindGameObjectWithTag("counterText").GetComponent<TextCounter>();
    }

    public void ShowResult() //Actuliza el array en consola y en escena
    {
        resultText.ArrayUpdate();
        ShowCount();
    }

    public void ShowCount()
    {
        counterText.CounterUpdate();
    }
}
