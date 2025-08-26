using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsEmptyTP02 : MonoBehaviour, IButtons
{
    private TP02Executer mainExecuter;

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        mainExecuter = GameObject.FindGameObjectWithTag("mainExecuter").GetComponent<TP02Executer>();

        button = GetComponent<Button>();

        //Agrega una funcion diferente en el evento onclick del boton (cuando se clickea) dependiendo del tag que posea el boton

        button.onClick.AddListener(OnClickAction);

    }

    public void OnClickAction() //Funcion clear
    {
        mainExecuter.myList.IsEmpty();

        mainExecuter.ShowResult();

        
    }
}
