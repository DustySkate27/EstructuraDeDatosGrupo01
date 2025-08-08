using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Grupo_01.TP01.Scripts
{
    public class Texts : MonoBehaviour
    {
        public TextMeshProUGUI resultText;
        private TP01Execute mainExecuter;


        private void Start()
        {
            resultText = GetComponent<TextMeshProUGUI>();
            mainExecuter = GameObject.FindGameObjectWithTag("mainExecuter").GetComponent<TP01Execute>();

            ArrayUpdate(); //muetra el array en patalla
        }


        public void ArrayUpdate() // Actualiza los resultado del arrey que deberian mostrarse en patalla
        {
            resultText.text = mainExecuter.intList.ToString();
        }

    }
}
