using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Texts : MonoBehaviour
{
    private TextMeshProUGUI resultText;
    private TP01Execute mainExecuter;

    private void Start()
    {

        mainExecuter = GameObject.FindGameObjectWithTag("mainExecuter").GetComponent<TP01Execute>();
        resultText = GetComponent<TextMeshProUGUI>();
    }

    public void ArrayUpdate() // Actualiza los resultado del array que deberian mostrarse en patalla
    {
        resultText.text = mainExecuter.intList.ToString();
    }

}

