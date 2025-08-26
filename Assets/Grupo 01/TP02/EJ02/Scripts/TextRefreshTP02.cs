using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextRefreshTP02 : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    private TP02Executer mainExecuter;

    private void Start()
    {
        resultText = GetComponent<TextMeshProUGUI>();
        mainExecuter = GameObject.FindGameObjectWithTag("mainExecuter").GetComponent<TP02Executer>();
    }

    public void ArrayUpdate() // Actualiza los resultado del arrey que deberian mostrarse en patalla
    {
        resultText.text = mainExecuter.myList.ToString();
    }
}
