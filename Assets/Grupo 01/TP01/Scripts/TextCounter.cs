using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextCounter : MonoBehaviour
{
    private TextMeshProUGUI counterText;
    private TP01Execute mainExecuter;

    private void Start()
    {
        counterText = GetComponent<TextMeshProUGUI>();
        mainExecuter = GameObject.FindGameObjectWithTag("mainExecuter").GetComponent<TP01Execute>();
    }

    public void CounterUpdate() // Actualiza los resultado del arrey que deberian mostrarse en patalla
    {
        Debug.Log("HOla");
        counterText.text = mainExecuter.intList.Count.ToString();
    }
}
