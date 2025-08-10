using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TextRefresher : MonoBehaviour
{   
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI countText;
    private TP01Execute mainExecuter;


    private void Start()
    {
        resultText = GetComponent<TextMeshProUGUI>();
        mainExecuter = GameObject.FindGameObjectWithTag("mainExecuter").GetComponent<TP01Execute>();
    }

    public void ArrayUpdate() // Actualiza los resultado del arrey que deberian mostrarse en patalla
    {
        resultText.text = mainExecuter.intList.ToString();
    }

    public void ArrayCount()
    {

    }
}
