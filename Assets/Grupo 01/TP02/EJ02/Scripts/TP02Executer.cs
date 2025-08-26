using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP02Executer : MonoBehaviour
{
    public MyList<string> myList = new MyList<string>();
    private TextRefreshTP02 resultText;

    void Start()
    {
        resultText = GameObject.FindGameObjectWithTag("resultText").GetComponent<TextRefreshTP02>();
    }

    public void ShowResult() //Actuliza el array en consola y en escena
    {
        resultText.ArrayUpdate();
        ShowCount();
    }

    private void ShowCount()
    {
        Debug.Log(myList.ToString());

        Debug.Log(myList.IsEmpty());

        Debug.Log(myList.Count);
    }
}
