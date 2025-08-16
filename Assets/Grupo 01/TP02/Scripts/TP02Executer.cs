using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP02Executer : MonoBehaviour
{
    public MyList<string> myList = new MyList<string>();

    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowResult() //Actuliza el array en consola y en escena
    {
        ShowCount();
    }

    public void ShowCount()
    {
        Debug.Log(myList.ToString());
    }
}
