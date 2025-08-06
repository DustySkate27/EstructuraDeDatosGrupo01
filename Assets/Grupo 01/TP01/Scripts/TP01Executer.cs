using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TP01Execute : MonoBehaviour
{
    private SimpleList<int> intList = new SimpleList<int>();
    private Texts texts;


    void Start()
    {
        intList.Add(0);
        intList.Add(1);
        intList.Add(2);
        intList.Add(6);

        Debug.Log(intList.ToString());

        texts = GameObject.FindGameObjectWithTag("resultText").GetComponent<Texts>();
        texts.resultText.text = intList.ToString();

    }

    // Update is called once per frame
    void Update()
    {

        

    }
}
